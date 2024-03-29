﻿using Domain.CartService.Entities;
using Domain.CartService.Models;
using Microsoft.AspNetCore.Mvc;
using RestMongo;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.CartService.Controllers
{
    public partial class CartsController
    {
        [HttpGet("{id}/items/{itemId}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404, "CONFLICT", typeof(ProblemDetails))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation("Get Cart item by ID", OperationId = "CartGetItemById")]

        public async virtual Task<ActionResult<CartItem>> GetItem(string id, string itemId)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            var item = _cartItemRepo.FindOneAsync(c => c.CartId == id && c.Id == itemId);
            return item.Transform<CartItem>();
        }

        [HttpGet("{id}/items")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404, "NOT FOUND", typeof(ProblemDetails))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation("Get Cart items by ID", OperationId = "CartGetAllItems")]
        public async virtual Task<ActionResult<IList<CartItem>>> GetAllItems(string id)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            var items = _cartItemRepo.FilterBy(c => c.CartId == id);
            return Ok(items.Transform<List<CartItem>>());
        }

        [HttpPost("{id}/items/")]
        [SwaggerResponse(200)]
        [SwaggerResponse(409, "CONFLICT", typeof(ProblemDetails))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation("update cart item by id", OperationId = "CartCreateItem")]
        public async virtual Task<ActionResult> CreateItem(string id, [FromBody] CartItemCreateModel value)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            var itemEntity = value.Transform<CartItemEntity>();
            itemEntity.CartId = id;
            await _cartItemRepo.InsertOneAsync(itemEntity);
            return Ok(itemEntity.Transform<CartItem>());
        }



        [HttpPut("{id}/items/{itemId}")]
        [SwaggerResponse(204, "NO CONTENT")]
        [SwaggerResponse(404, "NOT FOUND", typeof(ProblemDetails))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation("update cart item by id", OperationId = "CartUpdateItemById")]
        public async virtual Task<ActionResult<string>> UpdateItem(string id, string itemId, [FromBody] CartItemUpdateModel value)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            var itemEntity = value.Transform<CartItemEntity>();
            itemEntity.CartId = id;
            await _cartItemRepo.ReplaceOneAsync(itemEntity);
            return NoContent();
        }



        [HttpDelete("{id}/items/{itemId}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(404, "CONFLICT", typeof(ProblemDetails))]
        [SwaggerResponse(400)]
        [SwaggerResponse(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerOperation("delete cart item by id", OperationId = "CartDeleteItemById")]
        public async virtual Task<ActionResult<CartItem>> DeleteItem(string id, string itemId)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }

            await _cartItemRepo.DeleteByIdAsync(itemId);
            return NoContent();
        }

    }
}
