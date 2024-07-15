using MediatR;
using Resume_Shortlisting_Azure.Models.DTOs;

namespace Resume_Shortlisting_Azure.Features.Query
{
    public class GetEmployeeUserByIdQuery : IRequest<EmployeeUserDto>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}
