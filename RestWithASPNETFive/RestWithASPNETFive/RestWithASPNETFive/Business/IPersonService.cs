using RestWithASPNETFive.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETFive.Services
{
    public interface IPersonService
    {
        PersonVO Create(PersonVO person);

        PersonVO FindById(long id);

        List<PersonVO> FindAll();

        PersonVO Update(PersonVO person);

        void Delete(long id);


    }
}
