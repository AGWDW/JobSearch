using JobSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Pages.JobSeekers
{
    public class DetailsModel : PageModel
    {
        private readonly JobSearch.Data.JobSearchContext _context;

        public DetailsModel(JobSearch.Data.JobSearchContext context)
        {
            _context = context;
        }

        public JobSeeker JobSeeker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.JobSeekers == null)
            {
                return NotFound();
            }

            var jobseeker = await _context.JobSeekers.FirstOrDefaultAsync(m => m.ID == id);
            if (jobseeker == null)
            {
                return NotFound();
            }
            else
            {
                JobSeeker = jobseeker;
            }
            return Page();
        }
    }
}
