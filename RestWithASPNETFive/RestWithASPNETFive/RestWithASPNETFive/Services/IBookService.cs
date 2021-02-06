using RestWithASPNETFive.Models;
using System.Collections.Generic;

namespace RestWithASPNETFive.Services
{
    public interface IBookService
    {
        Book Create(Book book);
        Book Update(Book book);
        List<Book> FindAll();
        void Delete(long id);
        Book FindById(long id);

    }
}
