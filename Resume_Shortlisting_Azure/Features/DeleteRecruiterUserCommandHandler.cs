using MediatR;
using Resume_Shortlisting_Azure.Features.Command;
using Resume_Shortlisting_Azure.Models.Domain;
using Resume_Shortlisting_Azure.Repository.Interface;

namespace Resume_Shortlisting_Azure.Features
{
    
    public class DeleteRecruiterUserCommandHandler : IRequestHandler<DeleteRecruiterUserCommand>
    {
        private readonly IRepository<RecruiterUser> _repository;

        public DeleteRecruiterUserCommandHandler(IRepository<RecruiterUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteRecruiterUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }

        Task IRequestHandler<DeleteRecruiterUserCommand>.Handle(DeleteRecruiterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
