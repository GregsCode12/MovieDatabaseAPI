namespace MovieDatabaseAPI.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                

                List<Models.Actor> matrixActors = new List<Models.Actor>() {

                new Models.Actor() {
                    Name = "Laurence",
                    Surname = "Fishburne",
                    DateOfBirth = new DateTime(1961, 7, 30)
                },
                new Models.Actor() {
                    Name = "Hugo",
                    Surname = "Weaving",
                    DateOfBirth = new DateTime(1960, 4, 4)
                },
                new Models.Actor() {
                    Name = "Carrie Ann",
                    Surname = "Moss",
                    DateOfBirth = new DateTime(1967, 8, 21)
                },
                new Models.Actor() {
                          Name = "Keannu",
                        Surname = "Reeves",
                        DateOfBirth = new DateTime(1964, 9, 2)

                },

                };

                List<Models.Movie> matrixInfo = new List<Models.Movie>() { new Models.Movie()
                {
                    Title = "The Matrix",
                    Year = "1999",
                    Description = "Neo Smith and all that",
                    ImagePaths = "TestPath",
                    Actors = matrixActors,
                }
                };

                if (!context.Movies.Any() && !context.Actors.Any())
                {
                    context.Movies.Add(matrixInfo[0]);
                    context.SaveChanges();
                }

            }

        }
    }
}
