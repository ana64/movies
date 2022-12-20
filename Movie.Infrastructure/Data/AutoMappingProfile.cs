using AutoMapper;
using Movie.Core.Dto;
using Movie.Core.Entities;

namespace Movie.Infrastructure.Data
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<Staff, StaffDto>().ReverseMap();
            CreateMap<MovieReview, ReviewDto>().ReverseMap();
        }
     
    }
}
