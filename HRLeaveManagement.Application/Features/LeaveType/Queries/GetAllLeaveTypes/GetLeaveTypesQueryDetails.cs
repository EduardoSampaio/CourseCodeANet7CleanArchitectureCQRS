using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
public record GetLeaveTypesQueryDetails : IRequest<List<LeaveTypeDto>>;


