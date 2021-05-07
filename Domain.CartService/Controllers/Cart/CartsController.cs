using Domain.CartService.Entities;
using Domain.CartService.Models;
using Microsoft.AspNetCore.Mvc;
using RestMongo.Interfaces;
using System.Threading.Tasks;

namespace Domain.CartService.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("/carts")]
    [ApiController]

    public partial class CartsController : RestMongo.Controllers.ReadWriteController<CartEntity, Cart, CartCreateModel, CartUpdateModel>
    {
        private IRepository<CartEntity> _cartRepo;
        private IRepository<CartItemEntity> _cartItemRepo;

        public override Task<ActionResult<Cart>> Get(string id, [FromQuery(Name = "$expand")] string expand = "")
        {
            return base.Get(id, expand);
        }

        public CartsController(IRepository<CartEntity> cartRepo, IRepository<CartItemEntity> cartItemRepo) : base(cartRepo)
        {
            this._cartRepo = cartRepo;
            this._cartItemRepo = cartItemRepo;
        }
    }
}
