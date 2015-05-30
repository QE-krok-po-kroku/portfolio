using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectSimulator.Models;

namespace ProjectSimulatorTests
{
    public class TestDataProvider
    {
        public static Photo FirstPhoto(string grade = "good")
        {
            return new Photo
            {
                Id = "12345",
                Title = "Wielka Racza o świcie",
                Type = "Pejzaż",
                Year = 2008,
                Grade = grade
            };
        }
    }
}
