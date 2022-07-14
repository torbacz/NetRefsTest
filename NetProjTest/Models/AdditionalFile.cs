using System.Xml.Serialization;

namespace NetProjTest.Models;

public class AdditionalFile
{
    [XmlAttribute("Include")]
    public string Include { get; set; }
    [XmlElement("Link")]
    public string Link { get; set; }
}