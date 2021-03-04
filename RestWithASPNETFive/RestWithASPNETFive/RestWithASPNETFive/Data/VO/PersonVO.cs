using RestWithASPNETFive.Hypermedia;
using RestWithASPNETFive.Hypermedia.Abstract;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestWithASPNETFive.Data.VO
{
    public class PersonVO : ISupportsHypermedia
    {
        [JsonIgnore]
        public long Id { get; set; }
        [JsonPropertyName("primeiro_nome")]
        public string FirstName { get; set; }
        [JsonPropertyName("ultimo_nome")]
        public string LastName { get; set; }
        [JsonPropertyName("endereco")]
        public string Address { get; set; }
        [JsonPropertyName("sexo")]
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
