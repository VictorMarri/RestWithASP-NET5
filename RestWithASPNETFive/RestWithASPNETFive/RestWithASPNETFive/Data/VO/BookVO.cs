using System;
using System.Text.Json.Serialization;

namespace RestWithASPNETFive.Data.VO
{
    /// <summary>
    /// Classe que faz a representação da entidade base Book para VO
    /// </summary>
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
