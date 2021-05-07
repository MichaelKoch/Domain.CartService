using RestMongo.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.CartService.Models
{
    public class Cart
    {


        [IsQueryable()]
        [JsonPropertyName("Id")]
        [Required]
        public string Id { get; set; }

        [IsQueryable()]
        [JsonPropertyName("ExternalId")]
        public string ExternalId { get; set; }

        [IsQueryable()]
        [JsonPropertyName("CustomerId")]
        [Required]
        public string CustomerId { get; set; }


   
        [JsonPropertyName("Items")]
        public List<CartItemCreateModel> Items { get; set; }
    }
}
