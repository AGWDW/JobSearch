using AutoMapper;
using JobSearch.Models;
using JobSearch.Pages;

namespace JobSearch.Utils
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<JobListing, JobListingInput>();
        }
    }
}
