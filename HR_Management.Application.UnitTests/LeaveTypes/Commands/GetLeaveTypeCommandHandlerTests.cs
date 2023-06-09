using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveRequests.Handlers.Commands;
using HR_Management.Application.Features.LeaveTypes.Handlers.Commands;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Profiles;
using HR_Management.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR_Management.Application.UnitTests.LeaveTypes.Commands
{
    public class GetLeaveTypeCommandHandlerTests
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;
        CreateLeaveTypeDto _leaveTypeDto;
        public GetLeaveTypeCommandHandlerTests()
        {
            _mockRepository = MockLeaveRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfiles>();
            });
            _mapper = mapperConfig.CreateMapper();
            _leaveTypeDto = new CreateLeaveTypeDto()
            {
                Name = "Test",
                DefaultDay=15
            };
        }

        [Fact]
        public async Task CreateLeaveType()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepository.Object,_mapper);
            var result =await handler.Handle(new CreateLeaveTypeCommand()
            {
                LeaveTypeDto=_leaveTypeDto,
            },CancellationToken.None);

            result.ShouldBeOfType<int>();
            var leaveTypes = await _mockRepository.Object.GetAll();
            leaveTypes.Count.ShouldBe(3);
        }

    }
}
