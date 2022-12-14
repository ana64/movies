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
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/<JobController>
        [HttpGet]
        public IActionResult Get()
        {
            var jobs = _unitOfWork.Jobs.ReadAll();
            return Ok(jobs);
        }

        // GET api/<JobController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var jobs = _unitOfWork.Jobs.ReadById(id);
            return Ok(jobs);
        }

        // POST api/<JobController>
        [HttpPost]
        public IActionResult Post([FromBody] JobDto j, [FromServices] JobValidator validator)
        {
            validator.ValidateAndThrow(j);
            var job = _mapper.Map<Job>(j);

            _unitOfWork.Jobs.Create(job);
            _unitOfWork.Save();

            return StatusCode(201);
        }

        // PUT api/<JobController>/5
        [HttpPut]
        public IActionResult Put([FromBody] JobDto j)
        {
            var job = _mapper.Map<Job>(j);
            _unitOfWork.Jobs.Update(job);
            _unitOfWork.Save();

            return NoContent();
        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Jobs.Delete(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}
