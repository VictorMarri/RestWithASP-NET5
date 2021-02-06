using RestWithASPNETFive.Models;
using RestWithASPNETFive.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETFive.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {

        private readonly IRepository<Book> _repository;

        public BookServiceImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
