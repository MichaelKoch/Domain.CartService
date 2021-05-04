using RestMongo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.CartService.Controllers.Cart.Models
{
    public class Cart
    {
        

        [IsQueryableAttribute()]
        [JsonPropertyName("Id")] 
        
        public string Id { get; set; }

        [IsQueryableAttribute()]
        [JsonPropertyName("ExternalId")]
        public string ExternalId { get; set; }
        [IsQueryableAttribute()]
        [JsonPropertyName("CustomerId")] 
        public string CustomerId { get; set; }

        [JsonPropertyName("Name")] 
        public IList<CartItem> Items;
    }
}
