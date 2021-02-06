using Microsoft.EntityFrameworkCore;
using RestWithASPNETFive.Models.Base;
using RestWithASPNETFive.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETFive.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>(); //Aqui estamos setando o DbSet que fizemos na classe de contexto. Ele vai passar o dataset para 'T' que vai ser a classe que estiver em execução
        }

        public T Create(T entity)
        {
            try
            {
                dataset.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return entity;
        }


        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T entity)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(entity.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

                return result;
            }
            else
            {
                return null;
            }

        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }


        }

        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
