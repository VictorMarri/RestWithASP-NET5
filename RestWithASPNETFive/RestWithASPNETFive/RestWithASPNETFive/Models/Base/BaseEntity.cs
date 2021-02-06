using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETFive.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
