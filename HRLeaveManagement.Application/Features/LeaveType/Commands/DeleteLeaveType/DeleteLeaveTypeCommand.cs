using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
public record DeleteLeaveTypeCommand(int Id) : IRequest<Unit>;
