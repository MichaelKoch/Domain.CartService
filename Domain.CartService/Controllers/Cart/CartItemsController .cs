using Domain.CartService.Entities;
using Domain.CartService.Models;
using Microsoft.AspNetCore.Mvc;
using RestMongo.Interfaces;

namespace Domain.CartService.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("/carts")]
    [ApiController]
   
    public partial class CartItemsController : RestMongo.Controllers.ReadController<CartItemEntity,CartItem>
    {
       

        private IRepository<CartItemEntity> _cartItemRepo;

      
        public CartItemsController(IRepository<CartItemEntity> cartItemRepo) : base(cartItemRepo)
        {
         
            this._cartItemRepo = cartItemRepo;
        }   
    }
}
