using AutoMapper;
using MediatR;
using Resume_Shortlisting_Azure.Features.Query;
using Resume_Shortlisting_Azure.Models.Domain;
using Resume_Shortlisting_Azure.Models.DTOs;
using Resume_Shortlisting_Azure.Repository.Interface;

namespace Resume_Shortlisting_Azure.Features
{
    
    public class GetRecruiterUsersQueryHandler : IRequestHandler<GetRecruiterUsersQuery, IEnumerable<RecruiterUserDto>>
    {
        private readonly IRepository<RecruiterUser> _repository;
        private readonly IMapper _mapper;

        public GetRecruiterUsersQueryHandler(IRepository<RecruiterUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecruiterUserDto>> Handle(GetRecruiterUsersQuery request, CancellationToken cancellationToken)
        {
            var recruiterUsers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RecruiterUserDto>>(recruiterUsers);
        }
    }
}
