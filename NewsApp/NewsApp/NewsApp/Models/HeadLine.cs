using System.Collections.Generic;
using Newtonsoft.Json;

namespace NewsApp.Models
{

    public class HeadLine
    {
        [JsonIgnore]
        public string Title { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }
    }
}