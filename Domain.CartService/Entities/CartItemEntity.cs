using RestMongo.Attributes;
using System.Text.Json.Serialization;

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
