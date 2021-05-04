using RestMongo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.CartService.Models
{ 
    public class CartCreateModel
    {
        

     
        [JsonPropertyName("ExternalId")]
        public string ExternalId { get; set; }

        [JsonPropertyName("CustomerId")] 
        public string CustomerId { get; set; }

    }
}
