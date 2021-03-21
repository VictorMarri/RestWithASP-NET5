using RestWithASPNETFive.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETFive.Services
{
    public interface IBookService
    {
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        List<BookVO> FindAll();
        void Delete(long id);
        BookVO FindById(long id);

    }
}
