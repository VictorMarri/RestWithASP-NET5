using System.Text.Json.Serialization;

namespace RestWithASPNETFive.Data.VO
{
    /// <summary>
    /// Classe que faz a representação da entidade base Person para VO
    /// </summary>
    public class PersonVO
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

    }
}
