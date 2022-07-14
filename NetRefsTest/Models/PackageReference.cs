using System.Xml.Serialization;

namespace NetRefsTest.Models;

public class PackageReference
{
    [XmlAttribute("Include")]
    public string Include { get; set; }
    [XmlAttribute("Version")]
    public string Version { get; set; }
    [XmlElement("PrivateAssets")]
    public string PrivateAssets { get; set; }
    [XmlElement("IncludeAssets")]
    public string IncludeAssets { get; set; }
}