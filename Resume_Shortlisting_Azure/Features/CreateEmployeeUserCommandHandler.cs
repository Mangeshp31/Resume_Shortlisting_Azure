using AutoMapper;
using MediatR;
using Resume_Shortlisting_Azure.Features.Command;
using Resume_Shortlisting_Azure.Models.Domain;
using Resume_Shortlisting_Azure.Models.DTOs;
using Resume_Shortlisting_Azure.Repository.Interface;

namespace Resume_Shortlisting_Azure.Features
{
    

    public class CreateEmployeeUserCommandHandler : IRequestHandler<CreateEmployeeUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeUser> _repository;
        public CreateEmployeeUserCommandHandler(IRepository<EmployeeUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEmployeeUserCommand request, CancellationToken cancellationToken)
        {
            var employeeUser = _mapper.Map<EmployeeUser>(request.EmployeeUserDto);
            employeeUser.UserId = request.UserId;
            await _repository.AddAsync(employeeUser);
            return employeeUser.Id;
        }
    }
}
