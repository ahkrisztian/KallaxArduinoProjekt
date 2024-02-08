using KallaxArduinoObj.User;

namespace KallaxArduinoDataAccess.UserDataAccess;

public class UserAccess : IUserAccess
{
    private readonly ISQLDataAccess dataAccess;

    public UserAccess(ISQLDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }

    public async Task<UserModel> GetUserById(int id)
    {

        var output = await dataAccess.LoadData<UserModel, dynamic>(
                storedProcedure: "dbo.spSelectUserById",
                new { UserID = id },
                connectionStringName: "Default");

        if (output == null)
        {
            return null;
        }

        return output.FirstOrDefault();
    }
}
