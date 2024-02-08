using KallaxArduinoObj.Package;

namespace KallaxArduinoObj.Station;

public class ContainerWithPackages : ContainerModel
{
    public PackageModel PackageModel { get; set; } = new();

    public string DisplayPackageName => PackageModel.Number.ToString();
}
