namespace MovieDatabaseAPI.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public List<Actor> Actors { get; set; }
        public string ImagePaths { get; set; }
    }
}
