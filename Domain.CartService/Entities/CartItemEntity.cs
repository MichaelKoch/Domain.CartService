using RestMongo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.CartService.Entities
{
    public class CartItemEntity : RestMongo.Models.FeedDocument
    {
        [IsQueryableAttribute()]
        [JsonPropertyName("CartId")]
        public string CartId { get; set; }
         
        [IsQueryableAttribute()]
        [JsonPropertyName("ArticleId")]
        public string ArticleId { get; set; }

        [IsQueryableAttribute()]
        [JsonPropertyName("Quantity")]
        public decimal Quantity { get; set; }
    }
}
