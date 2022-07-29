using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.NetFramework;

[Browsable(false)]
public class NetFrameworkFile
{
    [XmlAttribute("Include")]
    public string Include { get; set; }
}