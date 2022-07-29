using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.NetFramework;

[Browsable(false)]
public class PackageNetFramework
{
    [XmlAttribute("id")]
    public string Id { get; set; }
    
    [XmlAttribute("version")]
    public string Version { get; set; }
    
    [XmlAttribute("targetFramework")]
    public string TargetFramework { get; set; }
    
    [XmlAttribute("developmentDependency")]
    public string DevelopmentDependency { get; set; }
}