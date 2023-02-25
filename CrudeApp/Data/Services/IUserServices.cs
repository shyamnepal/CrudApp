using CrudeApp.Models;

namespace CrudeApp.Data.Services
{
    public interface IUserServices
    {
        Task<UserDto> GetAll();
         void CreateUser(UserDto UserData);

        UserDto  GetUserById(int Id);

        void DeleteById(int Id);
        
    }
}
