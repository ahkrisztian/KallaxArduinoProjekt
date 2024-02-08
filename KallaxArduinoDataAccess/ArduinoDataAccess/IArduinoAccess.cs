
namespace KallaxArduinoDataAccess.ArduinoDataAccess
{
    public interface IArduinoAccess
    {
        Task<string> ReceivedDataFromArduino();
        Task<string>  SentDataToArduino(string data);

        public void CloseConnection();
    }
}