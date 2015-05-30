using System;
using System.Linq;
using Microsoft.Owin.Hosting;
using System.Data.Entity;
using ProjectSimulator.Models;

namespace ProjectSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing and seeding database...");
            Database.SetInitializer(new ApplicationDbInitializer());
            var db = new ApplicationDbContext();
            int count = db.Photos.Count();
            Console.WriteLine("Database created and seeded with {0} photos...", count);

            string baseUri = "http://localhost:8080";

            Console.WriteLine("Starting web Server...");
            WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
            Console.ReadLine();
        }
    }
}
