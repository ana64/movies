using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public  class Job : Entity
    {
        public string  Name { get; set; }

        public virtual ICollection<MovieStaff> MovieStaff { get; set; } = new List<MovieStaff>();
    }
}
