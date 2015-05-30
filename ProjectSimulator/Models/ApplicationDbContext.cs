using System.Data.Entity;

namespace ProjectSimulator.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("MyDatabase") {}

        public IDbSet<Photo> Photos { get; set; }
    }

    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            Photo[] photos = new Photo[]
            {
                new Photo
                {
                    Id = "12345",
                    Title = "Wielka Racza o świcie",
                    Type = "Pejzaż",
                    Year = 2008,
                    Grade = "BAD"
                },
                new Photo
                {
                    Id = "535354",
                    Title = "Wilk w lesie",
                    Type = "Przyrodnicza",
                    Year = 2004,
                    Grade = "VERY_BAD"
                }
            };

            foreach (Photo photo in photos)
            {
                context.Photos.Add(photo);
            }
        }
    }
}
