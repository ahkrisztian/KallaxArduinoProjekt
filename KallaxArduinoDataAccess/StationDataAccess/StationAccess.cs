using KallaxArduinoObj.Package;
using KallaxArduinoObj.Station;
using KallaxArduinoObj.User;

namespace KallaxArduinoDataAccess.StationDataAccess;

public class StationAccess : IStationAccess
{
    private readonly ISQLDataAccess dataAccess;

    public StationAccess(ISQLDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }

    public async Task<StationModel> GetStationById(int id)
    {
        //Load the package station
        var stationModel = await dataAccess.LoadData<StationModel, dynamic>(
                storedProcedure: "dbo.GetStationById",
                new { StationId = id },
                connectionStringName: "Default");

        if (stationModel == null)
        {
            return null;
        }

        //Load the users of a package station
        var userModels = await dataAccess.LoadData<UserModel, dynamic>(
                storedProcedure: "dbo.spSelectStationUsers",
                new { StationId = id },
                connectionStringName: "Default");

        if (stationModel == null)
        {
            stationModel.FirstOrDefault().Users = new();
        }
        else
        {
            stationModel.FirstOrDefault().Users.AddRange(userModels);
        }

        //Load the containers of a package station
        var containerModels = await dataAccess.LoadData<ContainerWithPackages, dynamic>(
                storedProcedure: "dbo.spSelectStationContainers",
                new { StationId = id },
                connectionStringName: "Default");

        if (stationModel == null)
        {
            stationModel.FirstOrDefault().ContainerModels = new();
        }
        else
        {
            stationModel.FirstOrDefault().ContainerModels.AddRange(containerModels);
        }

        //Load the packagees to the containers
        var packageModels = await dataAccess.LoadData<PackageModel, dynamic>(
                storedProcedure: "dbo.spSelectPackagesToContainers",
                new { StationId = id },
                connectionStringName: "Default");

        if (packageModels != null)
        {
            foreach(var container in containerModels)
            {
                foreach (var packageModel in packageModels)
                {
                    if(packageModel.ContainerId == container.Id)
                    {
                        container.PackageModel = packageModel;
                    }
                }
            }
        }


        return stationModel.FirstOrDefault();
    }
}
