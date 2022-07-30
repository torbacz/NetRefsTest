using System.ComponentModel;
using System.Xml.Serialization;

namespace NetProjTest.Models.Net60;

[Browsable(false)]
public class PropertyGroup
{
    private const string TrueValue = "True";
    private const string EnableValue = "Enable";
    
    private readonly Lazy<bool> generateDocumentationFile;
    private readonly Lazy<bool> checkForOverflowUnderflow;
    private readonly Lazy<bool> implicitUsings;
    private readonly Lazy<bool> isPackable;
    private readonly Lazy<bool> treatWarningsAsErrors;
    private readonly Lazy<TargetFramework?> targetFramework;
    
    [XmlElement("TargetFramework")]
    public string? TargetFrameworkRaw { get; set; }
    public TargetFramework? TargetFramework => targetFramework.Value;
    
    [XmlElement("ImplicitUsings")]
    public string? ImplicitUsingsRaw { get; set; }
    public bool ImplicitUsings => implicitUsings.Value;
    
    [XmlElement("Nullable")]
    public string? Nullable { get; set; }
    
    [XmlElement("IsPackable")]
    public string? IsPackableRaw { get; set; }
    public bool IsPackable => isPackable.Value;
    
    [XmlElement("TreatWarningsAsErrors")]
    public string? TreatWarningsAsErrorsRaw { get; set; }
    public bool TreatWarningsAsErrors => treatWarningsAsErrors.Value;
    
    [XmlElement("GenerateDocumentationFile")]
    public string? GenerateDocumentationFileRaw { get; set; }
    public bool GenerateDocumentationFile => generateDocumentationFile.Value;
    
    [XmlAttribute("Condition")]
    public string? Condition { get; set; }
    [XmlElement("CheckForOverflowUnderflow")]
    public string? CheckForOverflowUnderflowRaw { get; set; }

    public bool CheckForOverflowUnderflow => checkForOverflowUnderflow.Value;

    public PropertyGroup()
    {
        generateDocumentationFile = new Lazy<bool>(() => ParseFromString(GenerateDocumentationFileRaw, TrueValue));
        checkForOverflowUnderflow = new Lazy<bool>(() => ParseFromString(CheckForOverflowUnderflowRaw, TrueValue));
        implicitUsings = new Lazy<bool>(() => ParseFromString(ImplicitUsingsRaw, EnableValue));
        isPackable = new Lazy<bool>(() => ParseFromString(IsPackableRaw, TrueValue));
        treatWarningsAsErrors = new Lazy<bool>(() => ParseFromString(TreatWarningsAsErrorsRaw, TrueValue));
        targetFramework = new Lazy<TargetFramework?>(()=> TargetFrameworkFromRawString(TargetFrameworkRaw));
    }

    private static bool ParseFromString(string? value, string valueTrue)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;
        
        return value.Equals(valueTrue, StringComparison.OrdinalIgnoreCase);
    }

    private static TargetFramework? TargetFrameworkFromRawString(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;
        
        return value switch
        {
            "net6.0" => Models.TargetFramework.Net60,
            _ => throw new NotSupportedException($"Value {value} is not supported")
        };
    }
}