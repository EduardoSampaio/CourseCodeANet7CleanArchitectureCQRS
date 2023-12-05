namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
public record LeaveTypesDetailsDto(int Id, string Name, int DefaultDays, DateTime? DateCreated, DateTime? DateModified);
