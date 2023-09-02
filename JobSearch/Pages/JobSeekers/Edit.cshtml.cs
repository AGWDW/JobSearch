using JobSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Pages.JobSeekers
{
    public class EditModel : PageModel
    {
        private readonly JobSearch.Data.JobSearchContext _context;

        public EditModel(JobSearch.Data.JobSearchContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobSeeker JobSeeker { get; set; } = default!;

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
            JobSeeker = jobseeker;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(JobSeeker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobSeekerExists(JobSeeker.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobSeekerExists(int id)
        {
            return _context.JobSeekers.Any(e => e.ID == id);
        }
    }
}
