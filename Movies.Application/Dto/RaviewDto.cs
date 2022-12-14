using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Dto
{
    public class RaviewDto
    {
        public int MovieId { get; set; }

        public int UserId { get; set; }

        public string? Comment { get; set; }
        public int? Rate { get; set; }

    }
}
