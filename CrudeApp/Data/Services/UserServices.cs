using CrudeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudeApp.Data.Services
{
    public class UserServices : IUserServices
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> GetAll()
        {
            var AllUser = new UserDto()
            {
                UserList = _context.Users.ToList()
            };
            
            return AllUser;
        }

        public async void CreateUser(UserDto UserData)
        {
            if (UserData.UserData.Id > 0)
            {
                _context.Entry(UserData.UserData).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
               await _context.Users.AddAsync(UserData.UserData);
                _context.SaveChanges();
            }
           
            
        }
        public   UserDto GetUserById(int id)
        {
           
            var data = new UserDto()
            {
                UserList = _context.Users.ToList(),
                UserData = _context.Users.FirstOrDefault(x => x.Id == id)
            };
            return data;
        }
        public async void DeleteById(int Id)
        {
            var singleUser =  _context.Users.Find(Id);
            if (singleUser != null)
            {
                _context.Users.Remove(singleUser);
                _context.SaveChanges();
            }
        }
    }
}
