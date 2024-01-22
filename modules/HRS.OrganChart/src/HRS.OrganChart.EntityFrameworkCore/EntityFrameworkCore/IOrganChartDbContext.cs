using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HRS.OrganChart.EntityFrameworkCore;

[ConnectionStringName(OrganChartDbProperties.ConnectionStringName)]
public interface IOrganChartDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
