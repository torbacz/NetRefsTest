using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.NetFramework;

[Browsable(false)]
public class ItemGroup
{
    [XmlElement("Reference")]
    public List<Reference> References { get; set; }
    
    [XmlElement("Content")]
    public List<NetFrameworkFile> ContentFiles { get; set; }
}