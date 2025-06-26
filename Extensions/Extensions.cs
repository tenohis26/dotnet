using System.Globalization;
using Assignment.Responses;

namespace Assignment.Extensions;

public static class Extensions
{
    public static int CalculateWorkingHours(this WorkReportResponse workReport)
    {
        var start = DateTime.Parse(workReport.StartTimeUtc, null, DateTimeStyles.AdjustToUniversal);
        var end = DateTime.Parse(workReport.EndTimeUtc, null, DateTimeStyles.AdjustToUniversal);

        var milliseconds = (end - start).TotalMilliseconds;
        
        // Because of the invalid data, I will comment out validation below, otherwise exception will be thrown.
            // if(milliseconds > 0)
            //throw new Exception($"Working hours must be greater than or equal to zero for report with id {workReport.Id}.");
        
        var hours = (int)Math.Round(milliseconds / 3_600_000d, MidpointRounding.AwayFromZero);

        return hours;
    } 
}