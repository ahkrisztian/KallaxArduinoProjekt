using KallaxArduinoObj.Package;

namespace KallaxArduinoDataAccess.PackageDataAccess;

public class PackageAccess : IPackageAccess
{
    private readonly ISQLDataAccess dataAccess;

    public PackageAccess(ISQLDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }


    public async Task<PackageModel> GetPackageById(int id)
    {

        var output = await dataAccess.LoadData<PackageModel, dynamic>(
                storedProcedure: "dbo.spSelectPackageById",
                new { UserID = id },
                connectionStringName: "Default");

        if (output is not null)
        {
            return output.FirstOrDefault();
        }

        return null;
    }

    public async Task SetPackageStatus(PackageModel model)
    {
        await dataAccess.SaveData(
            storedProcedure: "dbo.SetPackageStatus",
            model,
            connectionStringName: "Default");
    }
}
