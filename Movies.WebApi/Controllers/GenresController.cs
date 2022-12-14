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
    public class GenresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GenresController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public IActionResult Get(int id)
        {
            var genre = _unitOfWork.Genres.ReadById(id);

            if(genre == null)
                return NotFound();

            return Ok(genre);
        }

        // POST api/<GenresController>
        [HttpPost]
        public IActionResult Post([FromBody] GenreDto g, [FromServices] GenreValidator validator)
        {
            validator.ValidateAndThrow(g);
            var genre = _mapper.Map<Genre>(g);

            _unitOfWork.Genres.Create(genre);
            _unitOfWork.Save();

            return StatusCode(201);
        }

        // PUT api/<GenresController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] GenreDto g)
        {
            var genre = _mapper.Map<Genre>(g);

            _unitOfWork.Genres.Update(genre);
            _unitOfWork.Save();

            return NoContent();
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Genres.Delete(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}
