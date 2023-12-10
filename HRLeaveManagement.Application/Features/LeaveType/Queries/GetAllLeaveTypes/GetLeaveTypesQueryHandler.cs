using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Logging;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
    private IMapper _mapper;
    private ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<GetLeaveTypeQueryHandler> _logger;

    public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetLeaveTypeQueryHandler> logger)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }

    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAsync();
        var dto = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        this._logger.LogInformation("Leave types were retrived successfully!");
        return dto;
    }
}
