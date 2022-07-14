using System.Xml.Serialization;

namespace NetRefsTest.Models;

public class AdditionalFiles
{
    [XmlAttribute("Include")]
    public string Include { get; set; }
    [XmlElement("Link")]
    public string Link { get; set; }
}