using Domain.CartService.Controllers.Cart.Models;
using Domain.CartService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestMongo;
using RestMongo.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.CartService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartsController : RestMongo.Controllers.ReadWriteController<CartEntity, Cart.Models.Cart, Cart.Models.CartEdit>
    {
        private IRepository<CartEntity> _cartRepo;
        private IRepository<CartItemEntity> _cartItemRepo;

        [HttpGet("{id}/items/{itemId}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404, "NOT FOUND", typeof(string))]
        [SwaggerOperation("Get Cart item by ID", OperationId = "CartGetItemById")]

        public async virtual Task<ActionResult<Cart.Models.CartItem>> GetItem(string id, string itemId)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            var item = _cartItemRepo.FindOneAsync(c => c.CartId == id && c.Id == itemId);
            return item.Transform<Cart.Models.CartItem>();
        }


        [HttpGet("{id}/items")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404, "NOT FOUND", typeof(string))]
        [SwaggerOperation("Get Cart items by ID", OperationId = "CartGetAllItems")]
        public async virtual Task<ActionResult<List<Cart.Models.CartItem>>> GetAllItems(string id)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            var items = _cartItemRepo.FilterBy(c => c.CartId == id);
            return Ok(items.Transform<List<Cart.Models.CartItem>>());
        }

        [HttpPost("{id}/items/")]
        [SwaggerResponse(204)]
        [SwaggerResponse(409, "CONFLICT")]
        [SwaggerOperation("update cart item by id", OperationId = "CartCreateItem")]
        public async virtual Task<ActionResult<Cart.Models.CartItem>> CreateItem(string id, [FromBody] Cart.Models.CartItemEdit value)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            var itemEntity = value.Transform<CartItemEntity>();
            itemEntity.CartId = id;

            await _cartItemRepo.InsertOneAsync(itemEntity);
            return Ok(itemEntity.Transform<Cart.Models.CartItem>());
        }



        [HttpPut("{id}/items/{itemId}")]
        [SwaggerResponse(204, "NO CONTENT")]
        [SwaggerResponse(404, "NOT FOUND")]
        [SwaggerOperation("update cart item by id", OperationId = "CartUpdateItemById")]
        public async virtual Task<ActionResult<string>> UpdateItem(string id, string itemId, [FromBody] Cart.Models.CartItemEdit value)
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
        [SwaggerResponse(404, "CONFLICT")]
        [SwaggerOperation("delete cart item by id", OperationId = "CartDeleteItemById")]
        public async virtual Task<ActionResult<Cart.Models.CartItem>> DeleteItem(string id, string itemId)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            //HINT : 204 --> OK ... whats about soft delete 
            //if (await _cartItemRepo.FindByIdAsync(itemId) == null)
            //{
            //    return NotFound();
            //}
            await _cartItemRepo.DeleteByIdAsync(itemId);
            return NoContent();
        }
     
        protected async override Task<Cart.Models.Cart> LoadRelations(Cart.Models.Cart value, IList<string> relations)
        {
            List<Task> waitfor = new List<Task>();
            if (relations.Contains("Items"))
            {
                relations.Remove("Items");
                waitfor.Add(loadItems(value.Id).ContinueWith(data => value.Items = data.Result));
            }
            Task.WaitAll(waitfor.ToArray());
            return value;
        }
        public override Task<ActionResult> Update(string id, [FromBody] CartEdit value)
        {

            return base.Update(id, value);


        }

        protected async Task<List<Cart.Models.CartItem>> loadItems(string cartID)
        {
            var entities = await Task.Run(()=> { return _cartItemRepo.FilterBy(c => c.CartId == cartID); });
            return entities.Transform<List<Cart.Models.CartItem>>();
        }
        public override Task<ActionResult> Delete(string id)
        {
            return null;
        }
        public CartsController(IRepository<CartEntity> cartRepo, IRepository<CartItemEntity> cartItemRepo) : base(cartRepo)
        {
            this._cartRepo = cartRepo;
            this._cartItemRepo = cartItemRepo;
         
        }   
    }
}
