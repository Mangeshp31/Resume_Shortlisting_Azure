using AutoMapper;
using MediatR;
using Resume_Shortlisting_Azure.Features.Query;
using Resume_Shortlisting_Azure.Models.Domain;
using Resume_Shortlisting_Azure.Models.DTOs;
using Resume_Shortlisting_Azure.Repository.Interface;

namespace Resume_Shortlisting_Azure.Features
{
    

    public class GetEmployeeUserByIdQueryHandler : IRequestHandler<GetEmployeeUserByIdQuery, EmployeeUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeUser> _repository;
        public GetEmployeeUserByIdQueryHandler(IRepository<EmployeeUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeUserDto> Handle(GetEmployeeUserByIdQuery request, CancellationToken cancellationToken)
        {
            var employeeUser = await _repository.GetByIdAsync(request.Id);
            if (employeeUser == null || employeeUser.UserId != request.UserId)
            {
                return null;
            }
            return _mapper.Map<EmployeeUserDto>(employeeUser);

        }
    }
}
