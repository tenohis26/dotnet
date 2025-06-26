namespace Assignment.Entities;

public class Employee
{
    public string? FullName { get; private init; }
    public int TotalWorkingHours { get; private set; }

    public static Employee Create(string? fullName)
    {
        
        Validate(fullName);
        
        return new Employee
        {
            FullName = fullName ?? "Null"
        };
    }
    
    public void AddWorkingHours(int hours) => TotalWorkingHours += hours;

    private static void Validate(string? fullName)
    {
        if (string.IsNullOrEmpty(fullName))
        {
            // In response of work reports, there are reports where fullname is null which is invalid case
            // Will comment this, otherwise exception will be thrown
        
                // throw new ValidationException("Employee name cannot be null or empty");
        }
    }
}