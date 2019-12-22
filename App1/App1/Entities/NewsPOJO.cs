using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace AppDemo.Entities
{
    public class NewsPOJO
    {
        [JsonProperty("status")]
        public string status {get; set;}
        
        [JsonProperty("totalResults")]
        public int totalResults { get; set; }

        [JsonProperty("articles")]
        public List<Articles> articles { get; set; }
    }
    public class Articles
    {
        [JsonProperty("source")]
        public Source source { get; set; }

        [JsonProperty("author")]
        public string author { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("urlToImage")]
        public string urlToImage { get; set; }

        [JsonProperty("publishedAt")]
        public DateTime publishedAt { get; set; }

        [JsonProperty("content")]
        public string content { get; set; }
    }
    public class Source
    {
        [JsonProperty("id")]
        public object id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

}
