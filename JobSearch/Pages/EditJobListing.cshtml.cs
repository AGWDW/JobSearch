using AutoMapper;
using JobSearch.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSearch.Pages
{
    public class JobListingInput
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime JobStartDate { get; set; }
        [Display(Name = "Listing Start Date")]
        [DataType(DataType.Date)]
        public DateTime ListingStartDate { get; set; }

        [Display(Name = "Listing End Date")]
        [DataType(DataType.Date)]
        public DateTime ListingEndDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

    }

    [Authorize(Roles = "Employer")]
    public class EditJobListingModel : PageModel
    {
        private readonly JobSearch.Data.JobSearchContext _context;
        private readonly IMapper _mapper;
        [BindProperty]
        public JobListingInput Input { get; set; } = new JobListingInput();


        public EditJobListingModel(Data.JobSearchContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync(int? id, bool creating = false)
        {
            if (id == null || _context.JobListings == null)
            {
                return NotFound();
            }

            var joblisting = await _context.JobListings.FirstOrDefaultAsync(m => m.ID == id);
            if (joblisting == null)
            {
                return NotFound();
            }

            Input = _mapper.Map<JobListingInput>(joblisting);

            ViewData["ListingID"] = id;
            ViewData["AppendText"] = !creating ? $"| Won't Save" : "";
            ViewData["EmployerID"] = new SelectList(_context.Employers, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var job = _context.Entry(await _context.FindAsync<JobListing>(id));
            if (job == null)
            {
                return NotFound();
            }
            job.CurrentValues.SetValues(Input);
            await _context.SaveChangesAsync();
            return RedirectToPage("./EmployerDetails");
        }
    }
}
