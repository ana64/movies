using Microsoft.AspNetCore.Mvc;
using Movies.Application.interfeces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<GenresController>
        [HttpGet]
        public IActionResult Get()
        {
            var genres = _unitOfWork.Genres.ReadAll();
            return Ok(genres);
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GenresController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
