using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Dto
{
    public class MovieDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Time { get; set; }
        public List<GenreDto>? Genres { get; set; }

        public List<ActorDto>? Actors { get; set; }

        // TODO: iNSERT IMAGES
        //public string? Poster { get; set; }
    }
}
