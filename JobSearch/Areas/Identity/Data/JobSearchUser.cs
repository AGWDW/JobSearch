using JobSearch.Models;
using Microsoft.AspNetCore.Identity;

namespace JobSearch.Areas.Identity.Data;

// Add profile data for application users by adding properties to the JobSearchUser class
public class JobSearchUser : IdentityUser
{
    [PersonalData]
    public int? JobSeekerID { get; set; }
    [PersonalData]
    public int? EmployerID { get; set; }

    // navigation property
    [PersonalData]
    public JobSeeker JobSeeker { get; set; }
    [PersonalData]
    public Employer Employer { get; set; }
}

