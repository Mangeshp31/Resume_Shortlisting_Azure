using AutoMapper;
using MediatR;
using Resume_Shortlisting_Azure.Features.Query;
using Resume_Shortlisting_Azure.Models.Domain;
using Resume_Shortlisting_Azure.Models.DTOs;
using Resume_Shortlisting_Azure.Repository.Interface;

namespace Resume_Shortlisting_Azure.Features
{
    
    public class SearchResumesQueryHandler : IRequestHandler<SearchResumesQuery, IEnumerable<EmployeeUserDto>>
    {
        private readonly IRepository<EmployeeUser> _repository;
        private readonly IMapper _mapper;

        public SearchResumesQueryHandler(IRepository<EmployeeUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeUserDto>> Handle(SearchResumesQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllAsync().Result.AsQueryable();

            if (!string.IsNullOrEmpty(request.Skills))
            {
                query = query.Where(e => e.Skills.Contains(request.Skills));
            }

            if (!string.IsNullOrEmpty(request.Location))
            {
                query = query.Where(e => e.Location.Contains(request.Location));
            }

            if (!string.IsNullOrEmpty(request.TechnologyDomain))
            {
                query = query.Where(e => e.TechnologyDomain.Contains(request.TechnologyDomain));
            }

            return _mapper.Map<IEnumerable<EmployeeUserDto>>(query);
        }
    }
}
