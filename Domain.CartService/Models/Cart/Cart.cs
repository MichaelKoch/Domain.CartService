using RestMongo.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

        [JsonPropertyName("Name")] 
        public IList<CartItem> Items;
    }
}
