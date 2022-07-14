using System.Xml.Serialization;

namespace NetProjTest.Models;

public class ItemGroup
{
    [XmlElement("PackageReference")]
    public List<PackageReference> PackageReferences { get; set; }
        
    [XmlElement("AdditionalFiles")]
    public List<AdditionalFile> AdditionalFiless { get; set; }
}