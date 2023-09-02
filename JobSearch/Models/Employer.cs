using System.ComponentModel.DataAnnotations;

namespace JobSearch.Models
{
    public class Employer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        // Navigation properties
        public IEnumerable<JobListing> JobListings { get; set; }

    }
}
