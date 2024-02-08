using KallaxArduinoObj.Station;

namespace KallaxArduinoDataAccess.StationDataAccess
{
    public interface IStationAccess
    {
        Task<StationModel> GetStationById(int id);
    }
}