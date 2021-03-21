using RestWithASPNETFive.Data.Converter.Implementations;
using RestWithASPNETFive.Data.VO;
using RestWithASPNETFive.Models;
using RestWithASPNETFive.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETFive.Services.Implementations
{
    public class BookServiceImplementation : IBookService
    {

        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookServiceImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookConvert = _converter.Parse(book);

            bookConvert = _repository.Create(bookConvert);

            return _converter.Parse(bookConvert);

        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookConvert = _converter.Parse(book);

            bookConvert = _repository.Update(bookConvert);

            return _converter.Parse(bookConvert);
        }
    }
}
