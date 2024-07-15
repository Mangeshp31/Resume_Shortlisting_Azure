using AutoMapper;

namespace Resume_Shortlisting_Azure.CommonProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Models.Domain.EmployeeUser, Models.DTOs.EmployeeUserDto>().ReverseMap();
            CreateMap<Models.Domain.RecruiterUser, Models.DTOs.RecruiterUserDto>().ReverseMap();
        
        }

    }
}
