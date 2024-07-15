using MediatR;
using Resume_Shortlisting_Azure.Models.DTOs;

namespace Resume_Shortlisting_Azure.Features.Query
{
    public class SearchResumesQuery : IRequest<IEnumerable<EmployeeUserDto>>
    {
        public string Skills { get; set; }
        public string Location { get; set; }
        public string TechnologyDomain { get; set; }

    }
}
