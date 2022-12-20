using System;
using System.Collections.Generic;

namespace Movie.Core.Entities
{
    public class Movie : Entity
    {
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Time { get; set; }  // in minutes
        public string? Poster { get; set; }



        public virtual ICollection<GenreMovie> Genres { get; set; } = new List<GenreMovie>();
        public virtual ICollection<ActorMovie> Actors { get; set; } = new List<ActorMovie>();
        public virtual ICollection<MovieStaff> MovieStaff { get; set; } = new List<MovieStaff>();
    }
}
