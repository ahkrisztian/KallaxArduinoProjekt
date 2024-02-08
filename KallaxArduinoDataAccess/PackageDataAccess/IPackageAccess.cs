using KallaxArduinoObj.Package;

namespace KallaxArduinoDataAccess.PackageDataAccess
{
    public interface IPackageAccess
    {
        Task<PackageModel> GetPackageById(int id);
        Task SetPackageStatus(PackageModel model);
    }
}