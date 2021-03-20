using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETFive.Models.Base
{
    /// <summary>
    /// Classe abstrata que representa a adição de Identificador
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// identificador
        /// </summary>
        [Column("id")]
        public long Id { get; set; }
    }
}
