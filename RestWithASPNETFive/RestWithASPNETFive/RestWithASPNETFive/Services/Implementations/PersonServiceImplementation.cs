using RestWithASPNETFive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
       
        private volatile int count;
        private Person person;

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
            List<Person> people = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }
            return people;
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

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Name" + i,
                LastName = "Last Name" + i,
                Address = "Address" + i,
                Gender = "Female"

            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
