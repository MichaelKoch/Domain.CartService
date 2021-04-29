using Domain.CartService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CartController : RestMongo.Controllers.ReadWriteController<CartEntity, Cart.Models.Cart, Cart.Models.Cart>
    {
        private IRepository<CartEntity> _cartRepo;
        private IRepository<CartEntity> _cartItemRepo;


        [HttpGet("{id}/items/{itemId}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404, "NOT FOUND", typeof(string))]
        [SwaggerOperation("Get Cart item by ID", OperationId ="getCartItemByID")]
        public async virtual Task<ActionResult<Cart.Models.CartItem>> GetItem(string id, string itemId)
        {
            return null;
        }


        [HttpPut("{id}/items/{itemId}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(409, "CONFLICT")]
        [SwaggerOperation("update cart item by id",OperationId ="updateCartItemByID")]
        public virtual ActionResult<Cart.Models.CartItem> PutItem([FromBody] Cart.Models.CartItem value)
        {
            return null;
        }

        [HttpDelete("{id}/items/{itemId}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404, "CONFLICT")]
        [SwaggerOperation("delete cart item by id", OperationId = "deleteCartItemByID")]
        public virtual ActionResult<Cart.Models.CartItem> DeleteItem([FromBody] Cart.Models.CartItem value)
        {
            return null;

        }

        public CartController(IRepository<CartEntity> cartRepo, IRepository<CartEntity> cartItemRepo) : base(cartRepo)
        {
            this._cartRepo = cartRepo;
            this._cartItemRepo = cartItemRepo;
        }
    }
}
