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
        }
    }
}
