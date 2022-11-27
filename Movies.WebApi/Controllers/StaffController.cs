using Microsoft.AspNetCore.Mvc;
using Movies.Application.interfeces;
using Movies.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        // GET: api/<StaffController>
        [HttpGet]
        public IActionResult Get()
        {
            var staff = _unitOfWork.Staffs.ReadAll();
            return Ok(staff);
        }

        // GET api/<StaffController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var staff = _unitOfWork.Staffs.ReadById(id);

            if(staff == null) return NotFound();

            return Ok();
        }

        // POST api/<StaffController>
        [HttpPost]
        public IActionResult Post([FromBody] Staff staff)
        {
            _unitOfWork.Staffs.Create(staff);
            _unitOfWork.Save();

            return StatusCode(201);
        }

        // PUT api/<StaffController>/5
        public IActionResult Put([FromBody] Staff staff)
        {
            _unitOfWork.Staffs.Update(staff);
            _unitOfWork.Save();

            return NoContent();
        }

        // DELETE api/<StaffController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Staffs.Delete(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}
