using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.NetFramework;

[Browsable(false)]
[XmlRoot("Project", Namespace = "http://schemas.microsoft.com/developer/msbuild/2003")]
public class NetFrameworkProject
{
    const string PackagesFileName = "packages.config";
    public string? ProjectName { get; set; }
    
    [XmlElement("PropertyGroup")]
    public List<PropertyGroup> PropertyGroups { get; set; }
    
    [XmlElement("ItemGroup")]
    public List<ItemGroup> ItemGroups { get; set; }
    
    public List<PackageNetFramework> Packages { get; set; }
    
    internal static NetFrameworkProject FromXmlString(string projectXml, string packagesXml, string projectName)
    {
        if (string.IsNullOrWhiteSpace(projectXml))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(projectXml));
        
        if (string.IsNullOrWhiteSpace(projectName))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(projectName));

        var serializerProject = new XmlSerializer(typeof(NetFrameworkProject));
        using TextReader reader = new StringReader(projectXml);
        
        var obj = serializerProject.Deserialize(reader) as NetFrameworkProject;
        if (obj == null) 
            throw new ArgumentNullException(nameof(obj));
        
        obj.ProjectName = projectName;

        if (string.IsNullOrWhiteSpace(packagesXml))
            return obj;
        
        var serializerPackages = new XmlSerializer(typeof(PackageWrapperNetFramework));
        using TextReader readerPackages = new StringReader(packagesXml);
        
        var packages = serializerPackages.Deserialize(readerPackages) as PackageWrapperNetFramework;
        if (packages == null) 
            throw new ArgumentNullException(nameof(packages));
        
        obj.Packages = packages.Packages;
        return obj;
    }
    
    internal static NetFrameworkProject FromFile(string filePath)
    {
        var projectXml = System.IO.File.ReadAllText(filePath);
        var projectName = Path.GetFileNameWithoutExtension(filePath);
        var packagesPath = $"{Path.GetDirectoryName(filePath)}//{PackagesFileName}";
        var packagesContent = System.IO.File.Exists(packagesPath)
            ? System.IO.File.ReadAllText(packagesPath)
            : string.Empty;
        return FromXmlString(projectXml, packagesContent, projectName);
    }
}