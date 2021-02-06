using RestWithASPNETFive.Models;
using RestWithASPNETFive.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETFive.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly IRepository<Person> _repository;


        public PersonServiceImplementation(IRepository<Person> repository)
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
