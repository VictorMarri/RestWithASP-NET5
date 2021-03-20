using Microsoft.EntityFrameworkCore;
using RestWithASPNETFive.Models.Base;
using RestWithASPNETFive.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETFive.Repository.Generic
{
    /// <summary>
    /// Classe que representa um repositorio generico para operações basicas de CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>(); //Aqui estamos setando o DbSet que fizemos na classe de contexto. Ele vai passar o dataset para 'T' que vai ser a classe que estiver em execução
        }

        /// <summary>
        /// Criar/Inserir um registro  de T no banco de dados
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Retorna o resultado da inserção e seu respectivo codigo</returns>
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

        /// <summary>
        /// Procura todos os registros dentro da tabela de T
        /// </summary>
        /// <returns>Retorna a lista com os itens cadastrados na lista de T</returns>
        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        /// <summary>
        /// Procura o registro com o respectivo ID passado dentro da tabela de T
        /// </summary>
        /// <param name="id">ID de registro procurado</param>
        /// <returns>Retorna o determinado registro com o ID repassado</returns>
        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        /// <summary>
        /// Atualiza um registro na tabela
        /// </summary>
        /// <param name="entity">Entidade de T passada para atualização</param>
        /// <returns>Retorna o JSON da entidade mais o codigo de registro da operação</returns>
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

        /// <summary>
        /// Deleta o respectivo registro
        /// </summary>
        /// <param name="id">ID do registro a ser excluido</param>
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

        /// <summary>
        /// Verifica se determinado ID existe como registro dentro de uma tabela
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna como true se o registro de fato existir</returns>
        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
