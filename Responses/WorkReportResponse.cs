using System.Text.Json.Serialization;

namespace Assignment.Responses;

public class WorkReportResponse(
    Guid id,
    string employeeName,
    string startTimeUtc,
    string endTimeUtc,
    string entryNotes,
    DateTime? deletedOn)
{
    public Guid Id { get; set; } = id;
    public string EmployeeName { get; set; } = employeeName;

    [JsonPropertyName("StarTimeUtc")]
    public string StartTimeUtc { get; set; } = startTimeUtc;
    public string EndTimeUtc { get; set; } = endTimeUtc;
    public string EntryNotes { get; set; } = entryNotes;
    public DateTime? DeletedOn { get; set; } = deletedOn;
};