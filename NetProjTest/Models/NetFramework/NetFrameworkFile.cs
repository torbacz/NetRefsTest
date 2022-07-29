using System.Xml.Serialization;

namespace NetProjTest.Models.NetFramework;

public class NetFrameworkFile
{
    [XmlAttribute("Include")]
    public string Include { get; set; }
}