using System.Text.Json;
using Assignment.Responses;

namespace Assignment.Services;

public class WorkReportService(IConfiguration configuration) : IWorkReportService
{
    private readonly string _employeeUrlEndpoint = configuration["ApiEndpoint"] ?? throw new Exception("ApiEndpoint not configured");
    public async Task<IEnumerable<WorkReportResponse>> GetWorkReportsAsync()
    {
        using var client = new HttpClient();
        try
        {
            var response = await client.GetAsync(_employeeUrlEndpoint);
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            
            var content = await response.Content.ReadAsStringAsync();
            
            var workReports = JsonSerializer.Deserialize<IEnumerable<WorkReportResponse>>(content) ?? throw new Exception("Deserialization of Work Reports failed");

            return workReports;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong: {ex.Message}");
            throw;
        }
    }
}