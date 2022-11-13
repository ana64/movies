using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class ActorMovie
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public string RoleName { get; set; }


        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
