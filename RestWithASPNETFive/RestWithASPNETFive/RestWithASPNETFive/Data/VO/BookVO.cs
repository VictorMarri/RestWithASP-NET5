using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Data.VO
{
    public class BookVO
    {
        [JsonIgnore]
        public long Id { get; set; }
        [JsonPropertyName("autor")]
        public string Author { get; set; }
        [JsonPropertyName("data_lancamento")]
        public DateTime LaunchDate { get; set; }
        [JsonPropertyName("preco")]
        public float Price { get; set; }
        [JsonPropertyName("titulo")]
        public string Title { get; set; }
    }
}
