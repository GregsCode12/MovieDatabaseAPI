using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MovieDatabaseAPI.Data.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
