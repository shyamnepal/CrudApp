using CrudeApp.Model;

namespace CrudeApp.Data.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAll();
        
    }
}
