using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Entities
{
    public class MovieStaff
    {
        public int MovieId { get; set; }
        public int StaffId { get; set; }
        public int JobId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Job Job { get; set; }
    }
}
