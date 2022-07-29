using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetProjTest.Models.NetFramework;

[Browsable(false)]
public class Reference
{
    [XmlAttribute("Include")]
    public string Include { get; set; }
    
    [XmlElement("HintPath")]
    public string HintPath { get; set; }
    
    [XmlElement("Private")]
    public string Private { get; set; }
}