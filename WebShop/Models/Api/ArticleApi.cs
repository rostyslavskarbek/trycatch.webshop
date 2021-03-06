﻿using Newtonsoft.Json;

namespace TryCatch.WebShop.Models.Api
{
    public class ArticleApi
    {
        [JsonProperty("articleId")]
        public string ArticleId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}