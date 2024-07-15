using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Resume_Shortlisting_Azure.Features.Command;
using Resume_Shortlisting_Azure.Models.Domain;
using Resume_Shortlisting_Azure.Models.DTOs;
using Resume_Shortlisting_Azure.Repository.Interface;
using Resume_Shortlisting_Azure.Services;


namespace Resume_Shortlisting_Azure.Features
{

    public class UpdateEmployeeUserCommandHandler : IRequestHandler<UpdateEmployeeUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly BlobStorageService _blobStorageService;
        private readonly IRepository<EmployeeUser> _repository;
        public UpdateEmployeeUserCommandHandler(IRepository<EmployeeUser> repository, IMapper mapper, BlobStorageService blobStorageService)
        {
            _repository = repository;
            _mapper = mapper;
            _blobStorageService = blobStorageService;
        }

        //public async Task<Unit> Handle(UpdateEmployeeUserCommand request, CancellationToken cancellationToken)
        //{
        //    var employeeUser = await _repository.GetByIdAsync(request.Id);
        //    if (employeeUser == null || employeeUser.UserId != request.UserId)
        //    {
        //        throw new UnauthorizedAccessException();
        //    }
        //    if (request.EmployeeUserDto.Resume != null)
        //    {
        //        if (!string.IsNullOrEmpty(employeeUser.ResumeFileName))
        //        {
        //            await _blobStorageService.DeleteFileAsync(employeeUser.ResumeFilename);
        //        }

        //        var resumeUrl = await _blobStorageService.UploadFileAsync(request.EmployeeUserDto.Resume);
        //        employeeUser.Resume = ;
        //    }

        //    _mapper.Map(request.EmployeeUserDto, employeeUser);

           


        //    await _repository.UpdateAsync(employeeUser);

        //    return Unit.Value;
           
        //}

        Task IRequestHandler<UpdateEmployeeUserCommand>.Handle(UpdateEmployeeUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Unit> Handle(UpdateEmployeeUserCommand request, CancellationToken cancellationToken)
        {
            var employeeUser = await _repository.GetByIdAsync(request.Id);
            if (employeeUser == null || employeeUser.UserId != request.UserId)
            {
                throw new UnauthorizedAccessException();
            }

            _mapper.Map(request.EmployeeUserDto, employeeUser);
            await _repository.UpdateAsync(employeeUser);
            return Unit.Value;
        }
    }
}
