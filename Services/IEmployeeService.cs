using Assignment.Entities;
using Assignment.Responses;

namespace Assignment.Services;

public interface IEmployeeService
{
    IEnumerable<Employee> GetEmployees(IEnumerable<WorkReportResponse> workReports);
}