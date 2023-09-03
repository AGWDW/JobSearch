using JobSearch.Data;
using JobSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly JobSearchContext _context;
        public string SearchString { get; set; }
        public IList<JobListing> JobListings { get; set; }

        public IndexModel(JobSearchContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(string searchString)
        {
            SearchString = searchString;
            if (string.IsNullOrWhiteSpace(SearchString))
            {
                JobListings = await _context.JobListings.ToListAsync();
            }
            else
            {
                IQueryable<JobListing> lisings = from j in _context.JobListings select j;
                JobListings = await lisings.Where(j => j.Name.ToLower().Contains(SearchString.ToLower())).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            const int userID = 1;

            JobListing job = await _context.JobListings.Include(l => l.Applied).FirstOrDefaultAsync(j => j.ID == id);
            JobSeeker me = await _context.JobSeekers.Include(j => j.JobsApplyedFor).FirstOrDefaultAsync(s => s.ID == userID);

            var applications = (HashSet<JobListing>)me.JobsApplyedFor;
            var applicants = (HashSet<JobSeeker>)job.Applied;

            if (!applications.Contains(job) && !applicants.Contains(me))
            {
                applications.Add(job);
                applicants.Add(me);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}