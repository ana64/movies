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
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public MovieController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _unitOfWork.Movies.ReadAll();
            return Ok(movies);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _unitOfWork.Movies.ReadById(id);

            if(movie == null) 
                return NotFound();

            return Ok(movie);
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] MovieDto m, [FromServices] MovieValidator validator)
        {
            validator.ValidateAndThrow(m);
            var movie = _mapper.Map<Movie>(m);

            _unitOfWork.Movies.Create(movie);
            _unitOfWork.Save();

            return StatusCode(201);
        }

        // PUT api/<MovieController>
        [HttpPut]
        public IActionResult Put( [FromBody] MovieDto m)
        {
            var movie = _mapper.Map<Movie>(m);
            _unitOfWork.Movies.Update(movie);
            _unitOfWork.Save();

            return NoContent();
    }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Movies.Delete(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}
