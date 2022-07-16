using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.Net60;

[Browsable(false)]
public class AdditionalFile
{
    [XmlAttribute("Include")]
    public string? Include { get; set; }
    [XmlElement("Link")]
    public string? Link { get; set; }
}