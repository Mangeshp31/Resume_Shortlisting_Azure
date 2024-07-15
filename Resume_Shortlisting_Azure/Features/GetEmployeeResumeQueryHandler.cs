using MediatR;
using Resume_Shortlisting_Azure.Features.Query;
using Resume_Shortlisting_Azure.Models.Domain;
using Resume_Shortlisting_Azure.Repository.Interface;

namespace Resume_Shortlisting_Azure.Features
{
    

    public class GetEmployeeResumeQueryHandler : IRequestHandler<GetEmployeeResumeQuery, byte[]>
    {
        private readonly IRepository<EmployeeUser> _repository;

        public GetEmployeeResumeQueryHandler(IRepository<EmployeeUser> repository)
        {
            _repository = repository;
        }

        public async Task<byte[]> Handle(GetEmployeeResumeQuery request, CancellationToken cancellationToken)
        {
            var employeeUser = await _repository.GetByIdAsync(request.Id);
            if (employeeUser == null)
            {
                return null;
            }

            return employeeUser.Resume;
        }
    }
}
