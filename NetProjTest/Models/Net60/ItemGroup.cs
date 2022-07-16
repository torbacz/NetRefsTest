using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.Net60;

[Browsable(false)]
public class ItemGroup
{
    [XmlElement("PackageReference")]
    public List<PackageReference>? PackageReferences { get; set; }
        
    [XmlElement("AdditionalFiles")]
    public List<AdditionalFile>? AdditionalFiless { get; set; }
}