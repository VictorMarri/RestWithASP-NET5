using RestWithASPNETFive.Data.Converter.Contract;
using RestWithASPNETFive.Data.VO;
using RestWithASPNETFive.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETFive.Data.Converter.Implementations
{
    /// <summary>
    /// Classe que realizará a converrsão dos dados da entidade base para um VO
    /// </summary>
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

        /// <summary>
        /// Lista de Persons para Lista de personVO 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>Entidade PersonVO</returns>
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

        /// <summary>
        /// Converte de PersonVO para Person
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>Entidade Person</returns>
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
