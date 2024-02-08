using KallaxArduinoObj.Station;

namespace KallaxArduinoDataAccess.StationDataAccess;

public interface IContainerAccess
{
    Task<ContainerModel> GetUserById(int id);
    Task SetContainerStatus(ContainerModel model);
    Task SetContainerDoorStatus(ContainerModel model);
}