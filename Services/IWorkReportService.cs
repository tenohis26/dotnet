using Assignment.Responses;

namespace Assignment.Services;

public interface IWorkReportService
{
    Task<IEnumerable<WorkReportResponse>> GetWorkReportsAsync();
}