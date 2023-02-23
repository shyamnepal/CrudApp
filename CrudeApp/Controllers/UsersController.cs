using CrudeApp.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudeApp.Controllers
{
  
    public class UsersController : Controller
    {
        private readonly IUserServices _service;
        public UsersController(IUserServices services)
        {
            _service = services;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            
            return View(data);

        }
    }
}
