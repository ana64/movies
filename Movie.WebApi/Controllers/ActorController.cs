using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dto;
using Movie.Core.Entities;
using Movie.Core.Interfeces;
using System;

namespace Movie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
     

        public  ActorController(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService ?? throw new ArgumentNullException(nameof(actorService)); ;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get()
        {
            var genres = _actorService.GetAll();

            return Ok(genres);
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var findGenre = _actorService.Find(id);
            if (!findGenre.Success && findGenre.Exception is ArgumentOutOfRangeException) return NotFound();

            if (!findGenre.Success) return BadRequest();

            return Ok(findGenre);
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] ActorDto dto)
        {
            var created = _actorService.Save(_mapper.Map<Actor>(dto));

            if (!created.Success) return BadRequest();

            return StatusCode(201);

        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActorDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var operationResult = _actorService.Update(_mapper.Map<Actor>(dto));
            if (!operationResult.Success) return BadRequest();


            return NoContent();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _actorService.Delete(id);

            if (!result.Success && result.Exception is ArgumentOutOfRangeException) return NotFound();
            if (!result.Success) return BadRequest();

            return NoContent();
        }


    }
}
