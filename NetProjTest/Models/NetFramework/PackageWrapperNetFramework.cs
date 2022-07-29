using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.NetFramework;

[Browsable(false)]
[XmlRoot("packages")]
public class PackageWrapperNetFramework
{
    [XmlElement("package")]
    public List<PackageNetFramework> Packages { get; set; } 
}