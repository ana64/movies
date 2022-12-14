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
    public class ReviewController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // POST api/<ReviewController>
        [HttpPost]
        public IActionResult Post([FromBody] RaviewDto dto, [FromServices] ReviewValidator validator)
        {
            validator.ValidateAndThrow(dto);
            var record = _mapper.Map<MovieReview>(dto);

            _unitOfWork.Reviews.Create(record);
            _unitOfWork.Save();

            return StatusCode(201);
        }


    }
}
