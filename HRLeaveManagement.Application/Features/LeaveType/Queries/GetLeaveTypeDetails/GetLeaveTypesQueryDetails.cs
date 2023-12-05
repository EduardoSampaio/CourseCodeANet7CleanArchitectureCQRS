using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypesDetailsDto>;


