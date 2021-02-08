using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETFive.Data.VO;
using RestWithASPNETFive.Models;
using RestWithASPNETFive.Services;

namespace RestWithASPNETFive.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v{version:apiVersion}/api/[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        //Pega do Body (FromBody) os dados de Person
        [HttpPost]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person.Equals(null))
            {
                return BadRequest();
            }

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person.Equals(null))
            {
                return BadRequest();
            }

            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var find = _personService.FindById(id);

            if (find == null)
            {
                return NotFound();
            }

            _personService.Delete(id);
            return Ok("Deleted.");
        }


    }
}
