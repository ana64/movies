using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Actor : People
    {
      
        public string? Biography { get; set; }

        public virtual ICollection<ActorMovie> ActorMovie { get; set; } = new List<ActorMovie>();
    }
}
