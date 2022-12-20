namespace Movie.Core.Dto
{
    public class ReviewDto
    {
        public int MovieId { get; set; }

        public int UserId { get; set; }

        public string Comment { get; set; }
        public int? Rate { get; set; }

    }
}
