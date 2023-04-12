using FluentValidation;
using HR_Management.Application.Contracts.Persistence;

namespace HR_Management.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestsDtoValidator : AbstractValidator<CreateLeaveRequestsDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public CreateLeaveRequestsDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            Include(new ILeaveRequestDtoValidator(_leaveRequestRepository));
        }
    }
}
