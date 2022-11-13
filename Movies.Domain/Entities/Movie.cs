using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Time { get; set; } 
        public string? Poster { get; set; }



        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public virtual ICollection<ActorMovie> Actors { get; set; } = new List<ActorMovie>();
        public virtual ICollection<MovieStaff> MovieStaff { get; set; } = new List<MovieStaff>();
    }
}
