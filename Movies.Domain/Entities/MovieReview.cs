using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    /// <summary>
    /// User can write review for movie
    /// </summary>
    public class MovieReview
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string? Comment { get; set; }
        public int? Rate { get; set; }
        public DateTime InsertDateTime { get; set; }


        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
