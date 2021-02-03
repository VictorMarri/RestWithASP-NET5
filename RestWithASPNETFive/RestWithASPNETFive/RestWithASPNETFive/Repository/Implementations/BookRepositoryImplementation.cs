using RestWithASPNETFive.Models;
using RestWithASPNETFive.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return book;
        }

        public void Delete(long id)
        {
            //Pra deletar alguma coisa, primeiro eu preciso ir no banco ver se essa coisa existe pelo menos
            var consulta = _context.Books.SingleOrDefault(p => p.id.Equals(id));

            if (consulta != null)
            {
                _context.Books.Remove(consulta);
                _context.SaveChanges();
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }


        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.id.Equals(id));
        }

        public Book Update(Book book)
        {
            if (!Exists(book.id))
                return null;

            var consulta = _context.Books.SingleOrDefault(p => p.id.Equals(book.id));

            if (consulta != null)
            {
                try
                {
                    _context.Entry(consulta).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                
            }

            return book;
            
        }

        public bool Exists(long id)
        {
           return _context.Books.Any(p => p.id.Equals(id));
        }
    }
}
