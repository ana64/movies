using AutoMapper;
using Movies.Application.Dto;
using Movies.Domain.Entities;

namespace Movies.Implementation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<Staff, StaffDto>().ReverseMap();
            CreateMap<MovieReview, RaviewDto>().ReverseMap();

            CreateMap<Movie, MovieDto>().ReverseMap()
                .ForMember(dto => dto.Genres, opt => opt.MapFrom(x => x.Genres))
                .ForMember(dto => dto.Actors, opt => opt.MapFrom(x => x.Actors));
           
        }
    }
}
