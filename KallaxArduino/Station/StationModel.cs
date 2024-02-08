using KallaxArduinoObj.User;

namespace KallaxArduinoObj.Station
{
    public enum StationStatus
    {
        Working,
        NotWorking
    }
    public class StationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public StationStatus StatStatus { get; set; }

        public List<ContainerWithPackages> ContainerModels { get; set; } = new();
        public List<UserModel> Users { get; set; } = new();
    }
}
