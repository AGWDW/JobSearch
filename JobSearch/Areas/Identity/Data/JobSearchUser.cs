using JobSearch.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.Areas.Identity.Data;

// Add profile data for application users by adding properties to the JobSearchUser class
public class JobSearchUser : IdentityUser
{
    [PersonalData]
    [Required]
    public int JobSeekerID { get; set; }

    // navigation property
    [PersonalData]
    public JobSeeker JobSeeker { get; set; }
}

