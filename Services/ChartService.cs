using Assignment.Entities;
using SkiaSharp;
using ScottPlot;

namespace Assignment.Services;

public class ChartService : IChartService
{
    public byte[] GeneratePieChartStream(List<Employee> employees)
    {
        if (employees is null || employees.Count == 0)
            throw new ArgumentException("Employee list is empty or null.");

        double totalHours = employees.Sum(e => e.TotalWorkingHours);
        if (totalHours == 0)
            throw new InvalidOperationException("Total working hours cannot be zero.");

        var labels = employees.Select(e => e.FullName).ToArray();
        var values = employees.Select(e => (double)e.TotalWorkingHours).ToArray();

        var plot = new Plot();

        var pie = plot.Add.Pie(values);

        plot.Legend.IsVisible = true;
        plot.Legend.Alignment = Alignment.UpperRight;

        for (var i = 0; i < labels.Length; i++)
            pie.Slices[i].Label = $"{labels[i]} ({values[i] / totalHours * 100:0.0}%)";

        plot.Axes.Frameless();
        plot.HideGrid();

        using var surface = SKSurface.Create(new SKImageInfo(600, 600));
        plot.Render(surface.Canvas, 600, 600);

        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 300);
        using var stream = new MemoryStream();
        data.SaveTo(stream);

        return stream.ToArray();
    }
}