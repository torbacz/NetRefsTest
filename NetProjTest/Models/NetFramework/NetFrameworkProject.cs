using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.NetFramework;

[Browsable(false)]
[XmlRoot("Project", Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public class NetFrameworkProject
{
    public string? ProjectName { get; set; }
    
    [XmlElement("PropertyGroup")]
    public List<PropertyGroup> PropertyGroups { get; set; }
    
    [XmlElement("ItemGroup")]
    public List<ItemGroup> ItemGroups { get; set; }
    
    public List<PackageNetFramework> Packages { get; set; } //TODO: From packages
    
    public static NetFrameworkProject FromXmlString(string xml, string projectName)
    {
        if (string.IsNullOrWhiteSpace(xml))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(xml));
        
        if (string.IsNullOrWhiteSpace(projectName))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(projectName));

        var serializer = new XmlSerializer(typeof(NetFrameworkProject));
        using TextReader reader = new StringReader(xml);
        
        var obj = serializer.Deserialize(reader) as NetFrameworkProject;
        if (obj == null) 
            throw new ArgumentNullException(nameof(obj));

        obj.ProjectName = projectName;
        return obj;
    }
    
    public static NetFrameworkProject FromFile(string filePath)
    {
        var projectXml = System.IO.File.ReadAllText(filePath);
        var projectName = Path.GetFileNameWithoutExtension(filePath);
        return FromXmlString(projectXml, projectName);
    }
}