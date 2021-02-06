using RestWithASPNETFive.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T entity);

        T FindById(long id);

        List<T> FindAll();

        T Update(T entity);

        void Delete(long id);

        bool Exists(long id);
    }
}
