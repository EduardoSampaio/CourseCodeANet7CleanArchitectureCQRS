using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;


