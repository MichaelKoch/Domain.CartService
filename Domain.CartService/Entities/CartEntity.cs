﻿using RestMongo.Attributes;
using System.Text.Json.Serialization;

namespace Domain.CartService.Entities
{
    public class CartEntity : RestMongo.Models.FeedDocument
    {
        //force clean (uri) free id's  // catch mongo id exceptions
      

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
