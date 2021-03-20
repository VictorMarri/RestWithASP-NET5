using RestWithASPNETFive.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETFive.Models
{
    /// <summary>
    /// Tabela que representa os livros cadastrados no sistema
    /// </summary>
    [Table("books")]
    public class Book : BaseEntity
    {
        /// <summary>
        /// Autor do livro
        /// </summary>
        [Column("author")]
        public string Author { get; set; }
        /// <summary>
        /// Data de lançamento do livro
        /// </summary>
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
        /// <summary>
        ///Preço do livro
        /// </summary>
        [Column("price")]
        public float Price { get; set; }
        /// <summary>
        /// Título do Livro
        /// </summary>
        [Column("title")]
        public string Title { get; set; }
    }
}
