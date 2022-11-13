using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public  class Genre : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
