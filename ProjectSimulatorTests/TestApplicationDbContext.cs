using System.Data.Entity;
using ProjectSimulator.Models;

namespace ProjectSimulatorTests
{
    public class TestApplicationDbContext : DbContext
    {
        public TestApplicationDbContext() : base("MyDatabase")
        {
        }

        public IDbSet<Photo> Photos { get; set; }
    }

    public class TestApplicationDbInitializer : DropCreateDatabaseAlways<TestApplicationDbContext>
    {
    }
}
