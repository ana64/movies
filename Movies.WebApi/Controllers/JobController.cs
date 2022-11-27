using Microsoft.AspNetCore.Mvc;
using Movies.Application.interfeces;
using Movies.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
        public IActionResult Post([FromBody] Job job)
        {
            _unitOfWork.Jobs.Create(job);
            _unitOfWork.Save();

            return StatusCode(201);
        }

        // PUT api/<JobController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Job job)
        {
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
