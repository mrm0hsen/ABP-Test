using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HRS.Employee.EntityFrameworkCore;

[ConnectionStringName(EmployeeDbProperties.ConnectionStringName)]
public interface IEmployeeDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
