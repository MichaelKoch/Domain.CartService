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
    public class CartItemController : RestMongo.Controllers.ReadWriteController<CartItemEntity, Cart.Models.CartItem, Cart.Models.CartItemEdit>
    {
   

        public CartItemController(IRepository<CartItemEntity> cartItemRepo) : base(cartItemRepo)
        {

           
        }
    }
}
