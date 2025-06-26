using Assignment.Services;

namespace Assignment;

public static class ServiceInjector
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return services.AddTransient<IWorkReportService, WorkReportService>()
            .AddTransient<IEmployeeService, EmployeeService>()
            .AddTransient<IChartService, ChartService>();
    }
}