using JobSearch.Data;
using JobSearch.Models;
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
            if (_context.JobSeekers != null)
            {
                JobListings = await _context.JobListings.ToListAsync();
            }
        }
    }
}