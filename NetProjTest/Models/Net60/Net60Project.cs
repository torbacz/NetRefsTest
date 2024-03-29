﻿using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.Net60;

[Browsable(false)]
[XmlRoot("Project")]
public class Net60Project
{
    public string? ProjectName { get; set; }
    [XmlAttribute("Sdk")]
    public string? Sdk { get; set; }
    [XmlElement("PropertyGroup")]
    public List<PropertyGroup>? PropertyGroups { get; set; }
    [XmlElement("ItemGroup")]
    public List<ItemGroup>? ItemGroups { get; set; }
    
    
    public static Net60Project FromXmlString(string xml, string projectName)
    {
        if (string.IsNullOrWhiteSpace(xml))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(xml));
        
        if (string.IsNullOrWhiteSpace(projectName))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(projectName));

        var serializer = new XmlSerializer(typeof(Net60Project));
        using TextReader reader = new StringReader(xml);
        
        var obj = serializer.Deserialize(reader) as Net60Project;
        if (obj == null) 
            throw new ArgumentNullException(nameof(obj));

        obj.ProjectName = projectName;
        return obj;
    }

    
    public static Net60Project FromFile(string fullFilePath)
    {
        var projectXml = System.IO.File.ReadAllText(fullFilePath);
        var projectName = Path.GetFileNameWithoutExtension(fullFilePath);
        return FromXmlString(projectXml, projectName);
    }
}