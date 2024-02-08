using KallaxArduinoObj.DTOS.ContainerDTOs;
using KallaxArduinoObj.Station;

namespace KallaxArduinoDataAccess.StationDataAccess;

public class ContainerAccess : IContainerAccess
{
    private readonly ISQLDataAccess dataAccess;

    public ContainerAccess(ISQLDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }

    public async Task<ContainerModel> GetUserById(int id)
    {

        var output = await dataAccess.LoadData<ContainerModel, dynamic>(
                 storedProcedure: "dbo.spSelectContainerById",
                 new { Id = id },
                 connectionStringName: "Default");

        if (output == null)
        {
            return null;
        }

        return output?.FirstOrDefault();
    }

    public async Task SetContainerStatus(ContainerModel model)
    {
        await dataAccess.SaveData(
            storedProcedure: "dbo.SetContainerStatus",
            model,
            connectionStringName: "Default");
    }

    public async Task SetContainerDoorStatus(ContainerModel model)
    {
        await dataAccess.SaveData(
            storedProcedure: "dbo.SetContainerDoorStatus",
            model,
            connectionStringName: "Default");
    }
}
