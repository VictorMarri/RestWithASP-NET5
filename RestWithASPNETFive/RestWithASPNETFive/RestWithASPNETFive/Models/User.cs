using RestWithASPNETFive.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Models
{
    /// <summary>
    /// Tabela que representa os dados dos usuarios autenticados no sistema.
    /// </summary>
    [Table("users")]
    public class User : BaseEntity
    {
        /// <summary>
        /// Nome de usuario
        /// </summary>
        [Column("user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// Nome completo do usuario
        /// </summary>
        [Column("full_name")]
        public string FullName { get; set; }
        /// <summary>
        /// Senha do usuario
        /// </summary>
        [Column("password")]
        public string Password { get; set; }
        /// <summary>
        /// Token de acesso do usuario
        /// </summary>
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
        /// <summary>
        /// Tempo de expiração do token do usuario
        /// </summary>
        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
