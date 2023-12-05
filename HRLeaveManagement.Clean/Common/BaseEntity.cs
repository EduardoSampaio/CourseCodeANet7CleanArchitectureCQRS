namespace HRLeaveManagement.Domain.Common;
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DatModified { get; set; }
}
