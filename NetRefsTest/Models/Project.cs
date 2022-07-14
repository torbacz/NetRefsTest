using System.Xml.Serialization;

namespace NetRefsTest.Models;

public class Project
{
    public string ProjectName { get; set; }
    [XmlAttribute("Sdk")]
    public string Sdk { get; set; }
    [XmlElement("PropertyGroup")]
    public List<PropertyGroup> PropertyGroups { get; set; }
    [XmlElement("ItemGroup")]
    public List<ItemGroup> ItemGroups { get; set; }
    
    
    public static Project FromXmlString(string xml, string projectName)
    {
        if (string.IsNullOrWhiteSpace(xml))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(xml));
        
        if (string.IsNullOrWhiteSpace(projectName))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(projectName));

        var serializer = new XmlSerializer(typeof(Project));
        using TextReader reader = new StringReader(xml);
        
        var obj = serializer.Deserialize(reader) as Project;
        if (obj == null) 
            throw new ArgumentNullException(nameof(obj));

        obj.ProjectName = projectName;
        return obj;
    }

    
    public static Project FromFile(string fullFilePath)
    {
        var projectXml = File.ReadAllText(fullFilePath);
        var projectName = Path.GetFileNameWithoutExtension(fullFilePath);
        return FromXmlString(projectXml, projectName);
    }
}