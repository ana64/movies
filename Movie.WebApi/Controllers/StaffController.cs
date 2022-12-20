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
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;

        public StaffController(IStaffService service, IMapper mapper)
        {
            _staffService = service ?? throw new ArgumentNullException(nameof(service)); ;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get()
        {
            var genres = _staffService.GetAll();

            return Ok(genres);
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var findGenre = _staffService.Find(id);
            if (!findGenre.Success && findGenre.Exception is ArgumentOutOfRangeException) return NotFound();

            if (!findGenre.Success) return BadRequest();

            return Ok(findGenre);
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] StaffDto dto)
        {
            var created = _staffService.Save(_mapper.Map<Staff>(dto));

            if (!created.Success) return BadRequest();

            return StatusCode(201);

        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StaffDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var operationResult = _staffService.Update(_mapper.Map<Staff>(dto));
            if (!operationResult.Success) return BadRequest();


            return NoContent();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _staffService.Delete(id);

            if (!result.Success && result.Exception is ArgumentOutOfRangeException) return NotFound();
            if (!result.Success) return BadRequest();

            return NoContent();
        }
    }
}
