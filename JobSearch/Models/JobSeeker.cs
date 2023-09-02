namespace JobSearch.Models
{
    public class JobSeeker
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Navigation properties
        public IEnumerable<JobListing> JobsApplyedFor { get; set; }
    }
}
