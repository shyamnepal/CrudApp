using CrudeApp.Model;
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
        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }
    }
}
