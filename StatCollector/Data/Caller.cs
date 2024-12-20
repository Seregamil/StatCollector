using System.Text.Json.Serialization;

namespace StatCollector.Data;

public class Caller
{
    /// <summary>
    /// Unique identifier of caller (Auto increment)
    /// </summary>
    public int Id { get; set; }
    
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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public virtual IEnumerable<Job> ExecutedJobs { get; set; }
}