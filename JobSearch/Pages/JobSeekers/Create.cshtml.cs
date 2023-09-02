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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobSeekers.Add(JobSeeker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
