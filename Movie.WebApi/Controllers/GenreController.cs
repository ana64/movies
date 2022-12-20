using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dto;
using Movie.Core.Entities;
using Movie.Core.Interfeces;
using Movie.Core.Shered.Results;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService)); ;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get()
        {
            var genres = _genreService.GetAll();

            return Ok(genres);
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var findGenre = _genreService.Find(id);
            if (!findGenre.Success && findGenre.Exception is ArgumentOutOfRangeException) return NotFound();

            if (!findGenre.Success) return BadRequest();

            return Ok(findGenre);
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] GenreDto dto)
        {
             var created =_genreService.Save(_mapper.Map<Genre>(dto));

             if(!created.Success) return BadRequest();

            return StatusCode(201);

        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenreDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var operationResult = _genreService.Update(_mapper.Map<Genre>(dto));
            if (!operationResult.Success) return BadRequest();

            
            return NoContent();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _genreService.Delete(id);

            if (!result.Success && result.Exception is ArgumentOutOfRangeException) return NotFound();
            if (!result.Success) return BadRequest();

            return NoContent();
        }
    }
}
