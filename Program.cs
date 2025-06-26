using Assignment;
using Assignment.Components;
using Assignment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();
builder.Services.RegisterServices();
builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();
app.MapControllers();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/chart/image", async (IWorkReportService workReportService, IEmployeeService employeeService, IChartService chartService) =>
{
    var workReports = await workReportService.GetWorkReportsAsync();
    var employees = employeeService.GetEmployees(workReports).ToList();

    var stream = chartService.GeneratePieChartStream(employees);

    return Results.File(stream, "image/png");
});

app.Run();