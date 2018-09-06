namespace Hello.Models
{
    class Movie {
        public string imdbID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Plot { get; set; }
        public string imdbRating { get; set; }
        public string Poster { get; set; }
        public string PosterLocalPath { get; set; }
        public float userRating { get; set; }
    }
}
