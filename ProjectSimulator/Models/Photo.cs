using System.ComponentModel.DataAnnotations;

namespace ProjectSimulator.Models
{
    public class Photo
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public string Grade { get; set; }
    }
}
