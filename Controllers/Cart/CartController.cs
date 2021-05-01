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
    public class CartController : RestMongo.Controllers.ReadWriteController<CartEntity, Cart.Models.Cart, Cart.Models.CartEdit>
    {
        private IRepository<CartEntity> _cartRepo;
        private IRepository<CartItemEntity> _cartItemRepo;
        private CartItemController _ctrl;

        [HttpGet("{id}/items/{itemId}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404, "NOT FOUND", typeof(string))]
        [SwaggerOperation("Get Cart item by ID", OperationId = "getCartItemByID")]
   
        public async virtual Task<ActionResult<Cart.Models.CartItem>> GetItem(string id, string itemId)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            return await _ctrl.Get(itemId);
        }


        [HttpGet("{id}/items")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404, "NOT FOUND", typeof(string))]
        [SwaggerOperation("Get Cart items by ID", OperationId = "getAllCartItems")]
        public async virtual Task<ActionResult<Cart.Models.CartItem>> GetItems(string id)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            return Ok(_cartItemRepo.FilterBy(c=> c.CartId ==id));
        }

        [HttpPost("{id}/items/")]
        [SwaggerResponse(204)]
        [SwaggerResponse(409, "CONFLICT")]
        [SwaggerOperation("update cart item by id", OperationId = "createCartItem")]
        public async virtual Task<ActionResult<Cart.Models.CartItem>> PostItem(string id, [FromBody] Cart.Models.CartItemEdit value)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            return await _ctrl.Post(value);
        }



        [HttpPut("{id}/items/{itemId}")]
        [SwaggerResponse(204,"NO CONTENT")]
        [SwaggerResponse(404, "NOT FOUND")]
        [SwaggerOperation("update cart item by id",OperationId ="updateCartItemByID")]
        public async virtual Task<ActionResult<string>> PutItem(string id, string itemId,[FromBody] Cart.Models.CartItemEdit value)
        {
            if(await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            return await _ctrl.Put(itemId, value);
        }

        [HttpDelete("{id}/items/{itemId}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404, "CONFLICT")]
        [SwaggerOperation("delete cart item by id", OperationId = "deleteCartItemByID")]
        public async virtual Task< ActionResult<Cart.Models.CartItem>> DeleteItem(string id,string itemId)
        {
            if (await _cartRepo.FindByIdAsync(id) == null)
            {
                return NotFound();
            }
            return await _ctrl.Delete(itemId);
        }

        public CartController(IRepository<CartEntity> cartRepo, IRepository<CartItemEntity> cartItemRepo) : base(cartRepo)
        {
            this._cartRepo = cartRepo;
            this._cartItemRepo = cartItemRepo;
            _ctrl = new CartItemController(this._cartItemRepo) { ControllerContext = this.ControllerContext };
        }
    }
}
