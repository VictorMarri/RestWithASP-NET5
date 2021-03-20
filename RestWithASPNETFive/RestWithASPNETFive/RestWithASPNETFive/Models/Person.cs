using RestWithASPNETFive.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETFive.Models
{
    /// <summary>
    /// Tabela que representa os dados das pessoas cadastradas no sistema
    /// </summary>
    [Table("person")]
    public class Person : BaseEntity
    {
        /// <summary>
        /// Primeiro Nome (cabe reuso)
        /// </summary>
        [Column("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Ultimo nome (cabe reuso)
        /// </summary>
        [Column("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Endereço do usuario
        /// </summary>
        [Column("address")]
        public string Address { get; set; }
        /// <summary>
        /// Gênero sexual do usuario
        /// </summary>
        [Column("gender")]
        public string Gender { get; set; }
    }
}
