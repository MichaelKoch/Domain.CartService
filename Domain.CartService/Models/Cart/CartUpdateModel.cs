using RestMongo.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.CartService.Models
{
    public class CartUpdateModel
    {
        

       
        [JsonPropertyName("ExternalId")]
        public string ExternalId { get; set; }
        
      
        [JsonPropertyName("CustomerId")]
        [Required]
        public string CustomerId { get; set; }

        
    }
}
