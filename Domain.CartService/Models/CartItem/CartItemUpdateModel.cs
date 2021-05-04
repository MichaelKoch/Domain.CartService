using RestMongo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.CartService.Models
{
    public class CartItemUpdateModel
    {
 
       
        [JsonPropertyName("ArticleId")]
        public string  ArticleId { get; set; }

     
        [JsonPropertyName("Quantity")]
        public decimal Quantity { get; set; }

    }
}
