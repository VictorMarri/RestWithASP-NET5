using RestWithASPNETFive.Models;
using RestWithASPNETFive.Models.Context;
using RestWithASPNETFive.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETFive.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly IPersonRepository _repository;
       

        public PersonServiceImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }


        public List<Person> FindAll()
        {

            return _repository.FindAll();
        }



        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {

            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);

        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

     


    }
}
