using KallaxArduinoObj.Package;
using KallaxArduinoObj.Station;

namespace KallaxArduinoObj.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int UserID { get; set; }
        public List<PackageModel> Packages { get; set; } = new();
        public List<StationModel> Stations { get; set; } = new();
    }
}
