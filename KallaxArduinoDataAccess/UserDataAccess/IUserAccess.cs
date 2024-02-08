using KallaxArduinoObj.User;

namespace KallaxArduinoDataAccess.UserDataAccess
{
    public interface IUserAccess
    {
        Task<UserModel> GetUserById(int id);
    }
}