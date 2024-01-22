using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace HRS.OrganChart.EntityFrameworkCore;

[ConnectionStringName(OrganChartDbProperties.ConnectionStringName)]
public class OrganChartDbContext : AbpDbContext<OrganChartDbContext>, IOrganChartDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public OrganChartDbContext(DbContextOptions<OrganChartDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureOrganChart();
    }
}
