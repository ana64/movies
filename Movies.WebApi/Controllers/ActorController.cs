using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Dto;
using Movies.Application.interfeces;
using Movies.Domain.Entities;
using Movies.Implementation.validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public IActionResult Post([FromBody] ActorDto a, [FromServices] ActorValidator validator)
        {
            validator.ValidateAndThrow(a);
            var actor = _mapper.Map<Actor>(a);

            _unitOfWork.Actors.Create(actor);
            _unitOfWork.Save();

            return StatusCode(201);
        }

        // PUT api/<ActorController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] ActorDto a)
        {
            var actor = _mapper.Map<Actor>(a);

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
