using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearch.Models
{
    public class JobListing
    {
        public int ID { get; set; }
        public int EmployerID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayFormat(NullDisplayText = "No Description Given")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime JobStartDate { get; set; }

        [Required]
        [Display(Name = "Listing Start Date")]
        [DataType(DataType.Date)]
        public DateTime ListingStartDate { get; set; }

        [Required]
        [Display(Name = "Listing End Date")]
        [DataType(DataType.Date)]
        public DateTime ListingEndDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2")]
        public double Salary { get; set; }
        // Navigation properites
        public IEnumerable<JobSeeker> Applied { get; set; }
        public Employer Employer { get; set; }
    }
}
