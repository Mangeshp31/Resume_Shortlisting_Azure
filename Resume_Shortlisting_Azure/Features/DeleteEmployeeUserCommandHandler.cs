using MediatR;
using Resume_Shortlisting_Azure.Features.Command;
using Resume_Shortlisting_Azure.Models.Domain;
using Resume_Shortlisting_Azure.Repository.Interface;

namespace Resume_Shortlisting_Azure.Features
{
    

    public class DeleteEmployeeUserCommandHandler : IRequestHandler<DeleteEmployeeUserCommand>
    {
        private readonly IRepository<EmployeeUser> _repository;
        public DeleteEmployeeUserCommandHandler(IRepository<EmployeeUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEmployeeUserCommand request, CancellationToken cancellationToken)
        {
            var employeeUser = await _repository.GetByIdAsync(request.Id);
            if (employeeUser == null || employeeUser.UserId != request.UserId)
            {
                throw new UnauthorizedAccessException();
            }
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }

        Task IRequestHandler<DeleteEmployeeUserCommand>.Handle(DeleteEmployeeUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
