using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.Net60;

[Browsable(false)]
public class PackageReference
{
    [XmlAttribute("Include")]
    public string? Include { get; set; }
    [XmlAttribute("Version")]
    public string? Version { get; set; }
    [XmlElement("PrivateAssets")]
    public string? PrivateAssets { get; set; }
    [XmlElement("IncludeAssets")]
    public string? IncludeAssets { get; set; }
}