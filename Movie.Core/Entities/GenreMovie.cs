namespace Movie.Core.Entities
{
    public class GenreMovie
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
