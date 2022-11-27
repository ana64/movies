﻿using Microsoft.AspNetCore.Mvc;
using Movies.Application.Dto;
using Movies.Application.interfeces;
using Movies.Domain.Entities;


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
        public IActionResult Get(int id)
        {
            var genre = _unitOfWork.Genres.ReadById(id);

            if(genre == null)
                return NotFound();

            return Ok(genre);
        }

        // POST api/<GenresController>
        [HttpPost]
        public IActionResult Post([FromBody] Genre genre)
        {
            _unitOfWork.Genres.Create(genre);
            _unitOfWork.Save();

            return StatusCode(201);
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody] Genre genre)
        {
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
