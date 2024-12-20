namespace StatCollector.Models;

public class JobDto
{
    /// <summary>
    /// Unique id (auto-increment)
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Job name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Job build id
    /// </summary>
    public int BuildId { get; set; }
    
    /// <summary>
    /// Job Url
    /// </summary>
    public string Url { get; set; }
    
    /// <summary>
    /// Execution status
    /// </summary>
    public string Status { get; set; }
    
    /// <summary>
    /// Stages information
    /// </summary>
    public IEnumerable<object> Stages { get; set; }
    
    /// <summary>
    /// Joined caller info
    /// </summary>
    public CallerDto Caller { get; set; }
}