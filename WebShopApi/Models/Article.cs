﻿using Newtonsoft.Json;

namespace TryCatch.WebShopApi.Models
{
    public class Article
    {
        [JsonProperty("artcileId")]
        public string ArticleId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}