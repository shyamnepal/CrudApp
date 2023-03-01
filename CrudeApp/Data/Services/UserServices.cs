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
        //Get All the user from the Database.
        
        public async Task<UserDto> GetAll()
        {
            try
            {
                var AllUser = new UserDto()
                {
                    UserList = _context.Users.ToList()
                };

                return AllUser;
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }


        }

        //Create and edit the user. 
        // First check if the user id greater than 0
        // then it edit the users else it create the new user.

        public async void CreateUser(UserDto UserData)
        {
            try
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
                
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
           
           
            
        }
        //This method is get the single user from the database. 
        //First it check id is null or 0 which means data is null and does not exist.
        // Then it create UserDto object to get all user from the database and single User
        //Because it is single page application where all user data show in the table and bleow 
        // the table it show the form for edit the user data. 
        public   UserDto GetUserById(int id)
        {
            try
            {
                if (id != null || id!=0)
                {

                    var data = new UserDto()
                    {
                        UserList = _context.Users.ToList(),
                        UserData = _context.Users.FirstOrDefault(x => x.Id == id)
                    };
                    return data;
                }
                else
                {
                    return null;
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
           
        }

        // Delete the User By id.
        // First it search data from the database by id if the user find then it delete the user data
        // and save changes in the database. 
        public async void DeleteById(int Id)
        {
            try
            {
                var singleUser = _context.Users.Find(Id);
                if (singleUser != null)
                {
                    _context.Users.Remove(singleUser);
                    _context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
          
        }
    }
}
