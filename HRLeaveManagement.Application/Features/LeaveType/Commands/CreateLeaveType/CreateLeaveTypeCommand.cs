using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
public record CreateLeaveTypeCommand(string Name, int DefaultDays) : IRequest<int>;
