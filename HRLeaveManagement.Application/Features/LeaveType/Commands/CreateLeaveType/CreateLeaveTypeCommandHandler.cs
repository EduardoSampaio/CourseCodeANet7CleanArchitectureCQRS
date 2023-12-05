using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{

    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveTypeCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid) throw new BadRequestException("Invalid LeaveType", validationResult);

        var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
        await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

        return leaveTypeToCreate.Id;
    }
}
