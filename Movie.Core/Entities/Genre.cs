using System.Collections.Generic;

namespace Movie.Core.Entities
{
    public  class Genre : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<GenreMovie> Movies { get; set; } = new List<GenreMovie>();
    }
}
