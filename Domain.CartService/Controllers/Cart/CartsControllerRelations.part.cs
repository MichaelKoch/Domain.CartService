using Domain.CartService.Models;
using RestMongo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.CartService.Controllers
{
    public partial class CartsController 
    {


        protected async override Task<Cart> LoadRelations(Cart value, IList<string> relationNames)
        {
            List<Task> waitfor = new List<Task>();
            if (relationNames.Contains("Items"))
            {
                relationNames.Remove("Items");
                waitfor.Add(loadItems(value.Id).ContinueWith(data => value.Items = data.Result));
            }
            Task.WaitAll(waitfor.ToArray());

            return value;
        }


        protected async Task<List<CartItem>> loadItems(string cartID)
        {
            var entities = await Task.Run(() => { return _cartItemRepo.FilterBy(c => c.CartId == cartID); });
            return entities.Transform<List<CartItem>>();
        }
    }
}
