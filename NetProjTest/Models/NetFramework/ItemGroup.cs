using System.Xml.Serialization;

namespace NetProjTest.Models.NetFramework;

public class ItemGroup
{
    [XmlElement("Reference")]
    public List<Reference> References { get; set; }
    
    [XmlElement("Content")]
    //[XmlElement("None")]
    public List<NetFrameworkFile> Files { get; set; } 
}