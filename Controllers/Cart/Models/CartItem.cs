using RestMongo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.CartService.Controllers.Cart.Models
{
    public class CartItem
    {

        [IsQueryableAttribute()]
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [IsQueryableAttribute()]
        [JsonPropertyName("CartId")]
        public string CartId{get;set; }
         
        [IsQueryableAttribute()]
        [JsonPropertyName("ArticleId")]
        public string  ArticleId { get; set; }

        [IsQueryableAttribute()]
        [JsonPropertyName("Quantity")]
        public Int32 Quantity { get; set; }

    }
}
