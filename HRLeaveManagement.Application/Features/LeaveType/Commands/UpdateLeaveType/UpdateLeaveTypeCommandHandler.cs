using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{

    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);
        await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

        return Unit.Value;
    }
}
