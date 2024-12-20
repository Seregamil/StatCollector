namespace ServiceMan.BaseLibrary.Models;

public class ServiceInfoDto(string name, string version)
{
    public string Name { get; set; } = name;

    public string Version { get; set; } = version;
}