﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HRS.Employee.EntityFrameworkCore;

[DependsOn(
    typeof(EmployeeDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class EmployeeEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<EmployeeDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
