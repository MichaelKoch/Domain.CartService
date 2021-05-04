using RestMongo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.CartService.Models
{
    public class CartItemCreateModel
    {

     
        [JsonPropertyName("ArticleId")]
        public string ArticleId { get; set; }


        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }

    }
}
