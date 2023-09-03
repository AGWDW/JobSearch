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
    }
}