namespace StatCollector.Data;

public class Job
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
    /// Job caller Id (See CallerModel.Id)
    /// </summary>
    public int CallerId { get; set; }
    
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
    public virtual Caller Caller { get; set; }
}