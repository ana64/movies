using Microsoft.AspNetCore.Mvc;
using Movies.Application.interfeces;
using Movies.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ActorController>
        [HttpGet]
        public IActionResult Get()
        {
            var actors = _unitOfWork.Actors.ReadAll();
            return Ok(actors);
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var actor = _unitOfWork.Actors.ReadById(id);
            return Ok(actor);
        }

        // POST api/<ActorController>
        [HttpPost]
        public IActionResult Post([FromBody] Actor actor)
        {
            _unitOfWork.Actors.Create(actor);
            _unitOfWork.Save();

            return StatusCode(201);
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody] Actor actor)
        {
            _unitOfWork.Actors.Update(actor);
            _unitOfWork.Save();

            return NoContent();
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Actors.Delete(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}
