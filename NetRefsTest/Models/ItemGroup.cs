using System.Xml.Serialization;

namespace NetRefsTest.Models;

public class ItemGroup
{
    [XmlElement("PackageReference")]
    public List<PackageReference> PackageReferences { get; set; }
        
    [XmlElement("AdditionalFiles")]
    public List<AdditionalFiles> AdditionalFiless { get; set; }
}