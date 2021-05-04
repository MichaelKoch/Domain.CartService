using RestMongo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.CartService.Entities
{
    public class CartEntity:RestMongo.Models.FeedDocument
    {
        //force clean (uri) free id's  // catch mongo id exceptions
        public override string Id { get => base.Id
                ; set => base.Id = value; }
        
        
        [IsQueryableAttribute()]
        [JsonPropertyName("ExternalId")]
        public string ExternalId { get; set; }

        [IsQueryableAttribute()]
        [JsonPropertyName("CartId")]
        public string CartId { get; set; }

        [IsQueryableAttribute()]
        [JsonPropertyName("CustomerId")]
        public string CustomerId { get; set; }

    }
}
