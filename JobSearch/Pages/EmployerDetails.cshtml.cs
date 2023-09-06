using JobSearch.Areas.Identity.Data;
using JobSearch.Data;
using JobSearch.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Pages
{
    [Authorize(Roles = "Employer")]
    public class EmployerDetailsModel : PageModel
    {
        private class EmployerDetailsInput
        {
        }
        [BindProperty]
        public Employer Employer { get; set; }
        private readonly UserManager<JobSearchUser> _usermanager;
        private readonly JobSearchContext _context;

        public EmployerDetailsModel(UserManager<JobSearchUser> usermanager, JobSearchContext context)
        {
            _usermanager = usermanager;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            JobSearchUser user = await _usermanager.GetUserAsync(User);
            Employer = await _context.Employers.Include(x => x.JobListings).ThenInclude(x => x.Applied).FirstOrDefaultAsync(x => x.ID == user.EmployerID);
        }

        public async Task OnPostAsync()
        {

        }
        public async Task<IActionResult> OnPostCreateAsync(int id)
        {
            JobListing job = new JobListing
            {
                Name = "Test Job Listing",
            };
            Employer employer = await _context.Employers.Include(_ => _.JobListings).FirstOrDefaultAsync(x => x.ID == id);

            ((HashSet<JobListing>)employer.JobListings).Add(job);
            _context.JobListings.Add(job);
            _context.SaveChanges();
            return RedirectToPage("EditJobListing", new { id = job.ID, creating = true });
        }

        public HashSet<JobListing> GetJobListings()
        {
            return (HashSet<JobListing>)Employer.JobListings;
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var listing = await _context.JobListings.FindAsync(id);

            if (listing != null)
            {
                _context.JobListings.Remove(listing);
                await _context.SaveChangesAsync();
            }
            return Redirect(Request.Path);
        }
    }
}
