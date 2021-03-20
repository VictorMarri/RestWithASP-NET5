using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETFive.Models.Context
{
    /// <summary>
    /// Classe de contexto que representa a conexão e criação de tabelas no banco de dados
    /// </summary>
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {
        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        /// <summary>
        /// Tabela de Pessoas
        /// </summary>
        public DbSet<Person> Persons { get; set; }
        /// <summary>
        /// Tabela de livros
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// Tabelas de Usuarios para fins de autenticação
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
