using HRLeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Identity.DbContext;
public class HrLeaveManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
{

    public HrLeaveManagementIdentityDbContext(DbContextOptions<HrLeaveManagementIdentityDbContext> options) 
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(HrLeaveManagementIdentityDbContext).Assembly);
    }
}
