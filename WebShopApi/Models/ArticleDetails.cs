using Newtonsoft.Json;

namespace TryCatch.WebShopApi.Models
{
    public class ArticleDetails
    {
        [JsonProperty("articleId")]
        public string ArticleId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }
    }
}