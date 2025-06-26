using Assignment.Entities;
using Assignment.Extensions;
using Assignment.Responses;

namespace Assignment.Services;

public class EmployeeService : IEmployeeService
{
    public IEnumerable<Employee> GetEmployees(IEnumerable<WorkReportResponse> workReports)
    {
        var groupedEmployees = workReports
            .Where(report => report.DeletedOn is null)
            .GroupBy(report => report.EmployeeName)
            .Select(group =>
            {
                var employee = Employee.Create(group.Key);
                var totalHours = group.Sum(report => report.CalculateWorkingHours());
                employee.AddWorkingHours(totalHours);
                return employee;
            })
            .OrderByDescending(e => e.TotalWorkingHours);

        return groupedEmployees;
    }
}