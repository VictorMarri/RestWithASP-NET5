using RestWithASPNETFive.Models;
using RestWithASPNETFive.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {

        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {

            return _context.Persons.ToList();
        }

       

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Victor",
                LastName = "Marri",
                Address = "Eleven Street, CA",
                Gender = "Male"
                
            };
        }

        public Person Update(Person person)
        {
            //Ir ate a base, fazer o Update e retornar a pessoa
            return person;
        }


    }
}
