namespace MovieDatabaseAPI.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public string ImagePaths { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
