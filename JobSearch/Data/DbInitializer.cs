using JobSearch.Models;

namespace JobSearch.Data
{
    public static class DbInitializer
    {
        public static void Initialize(JobSearchContext context)
        {
            if (context.JobSeekers.Any())
            {
                return;
            }

            var seekers = new JobSeeker[]
            {
                new JobSeeker{FirstName="Alexander", LastName="Ghosh"},
                new JobSeeker{FirstName="Isabelle", LastName="Ghosh"}
            };
            context.JobSeekers.AddRange(seekers);
            context.SaveChanges();



            Employer bbc = new Employer
            {
                Name = "BBC"
            };

            JobListing softwareDev = new JobListing
            {
                Name = ".NET Developer",
                JobStartDate = DateTime.Today.AddMonths(1),
                ListingStartDate = DateTime.Today,
                ListingEndDate = DateTime.Today.AddMonths(1).AddDays(-7),
                Salary = 40_000.00,
                Employer = bbc
            };

            // softwareDev.Employer = bbc;

            context.Employers.Add(bbc);
            context.SaveChanges();

            context.JobListings.Add(softwareDev);
            context.SaveChanges();
        }
    }
}
