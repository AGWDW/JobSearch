using JobSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobSearch.Pages.JobSeekers
{
    public class CreateModel : PageModel
    {
        private readonly JobSearch.Data.JobSearchContext _context;

        public CreateModel(JobSearch.Data.JobSearchContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobSeeker JobSeeker { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyJobSeeker = new JobSeeker();

            if (await TryUpdateModelAsync<JobSeeker>(
                emptyJobSeeker,
                "student",   // Prefix for form value.
                s => s.FirstName, s => s.LastName))
            {
                _context.JobSeekers.Add(emptyJobSeeker);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
