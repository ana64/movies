using System.Collections.Generic;

namespace Movie.Core.Entities
{
    public class Actor : People
    {

        public string Biography { get; set; }

        public virtual ICollection<ActorMovie> ActorMovie { get; set; } = new List<ActorMovie>();
    }
}
