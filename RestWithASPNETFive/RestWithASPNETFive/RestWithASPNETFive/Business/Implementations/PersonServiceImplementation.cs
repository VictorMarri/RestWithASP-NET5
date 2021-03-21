using RestWithASPNETFive.Data.Converter.Implementations;
using RestWithASPNETFive.Data.VO;
using RestWithASPNETFive.Models;
using RestWithASPNETFive.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETFive.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonServiceImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }


        public List<PersonVO> FindAll()
        {

            return _converter.Parse(_repository.FindAll());
        }



        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Create(PersonVO person)
        {
            //Quando um objeto chega, a gente nao consegue persistir ele na base de dadosm pq é um VO e nao uma entidade
            //Entao a gente precisa parsear ele pra entidade
            var personEntity = _converter.Parse(person);
            //Depois de parsear pra entidade, eu posso ir la e persistir no banco, devolvendo pra personEntity
            personEntity = _repository.Create(personEntity);
            //Depois a gente converte essa entidade pra VO e devolve a resposta, pq o metodo pede q o retorno seja VO
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            //Pra inserir no banco, precisa de ser entidade, não V.O
            //Converto pra entidade
            var personEntity = _converter.Parse(person);
            //Insiro no banco
            personEntity = _repository.Update(personEntity);
            //retorno como um VO novamente, convertendo a conversão q eu fiz pra entity, pra VO dnv
            return _converter.Parse(personEntity);

        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }




    }
}
