using RestWithASPNETFive.Data.Converter.Contract;
using RestWithASPNETFive.Data.VO;
using RestWithASPNETFive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        /// <summary>
        /// VO para Person
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public Person Parse(PersonVO origin)
        {
            if (origin == null)
            {
                return null;
            }

            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();

        }
        /// <summary>
        /// Person para VO
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public PersonVO Parse(Person origin)
        {
            if (origin == null)
            {
                return null;
            }

            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
