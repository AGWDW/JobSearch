using JobSearch.Areas.Identity.Data;
using JobSearch.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Data
{
    public class JobSearchContext : IdentityDbContext<JobSearchUser, IdentityRole, string>
    {
        public JobSearchContext(DbContextOptions<JobSearchContext> options)
            : base(options)
        {
        }

        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobListing> JobListings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobSeeker>().ToTable("JobSeeker");
            modelBuilder.Entity<Employer>().ToTable("Employer");
            modelBuilder.Entity<JobListing>().ToTable("JobListing").HasMany(d => d.Applied).WithMany(d => d.JobsApplyedFor);
            base.OnModelCreating(modelBuilder);
        }
    }
}
