using SQLite;

namespace Hello.Models
{
    public class Movie {
        [PrimaryKey]
        public string imdbID { get; set; } = "";
        public string Title { get; set; } = "";
        public int Year { get; set; }
        public string Genre { get; set; } = "";
        public string Director { get; set; } = "";
        [MaxLength(1024)]
        public string Plot { get; set; } = "";
        public string imdbRating { get; set; } = "";
        [MaxLength(512)]
        public string Poster { get; set; } = "";
        [MaxLength(512)]
        public string PosterLocalPath { get; set; } = "";
        public float userRating { get; set; } = 0;
    }
}
