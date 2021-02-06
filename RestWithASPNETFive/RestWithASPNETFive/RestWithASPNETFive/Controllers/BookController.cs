using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETFive.Models;
using RestWithASPNETFive.Services;

namespace RestWithASPNETFive.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/api/[controller]")]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var pesquisa = _bookService.FindById(id);

            if (pesquisa == null)
            {
                return NotFound();
            }

            return Ok(pesquisa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            return Ok(_bookService.Create(book));
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var find = _bookService.FindById(id);

            if (find == null)
            {
                return NotFound();
            }

            _bookService.Delete(id);
            return Ok("Deleted");
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            return Ok(_bookService.Update(book));
        }
    }
}
