using JobSearch.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Pages.JobSeekers
{
    public class IndexModel : PageModel
    {
        private readonly JobSearch.Data.JobSearchContext _context;

        public IndexModel(JobSearch.Data.JobSearchContext context)
        {
            _context = context;
        }

        public IList<JobSeeker> JobSeeker { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.JobSeekers != null)
            {
                JobSeeker = await _context.JobSeekers.ToListAsync();
            }
        }
    }
}
