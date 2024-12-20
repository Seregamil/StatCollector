namespace StatCollector.Models;

public class CallerDto
{
    /// <summary>
    /// Sber user login
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// View name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Internal email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Pool of executed jobs
    /// </summary>
    public IEnumerable<int>? ExecutedJobs { get; init; }
}