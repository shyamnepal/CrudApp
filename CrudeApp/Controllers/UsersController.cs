using CrudeApp.Data.Services;
using CrudeApp.Models;
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

       
        public async Task<IActionResult> NewUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserDto u)
        {
            if (u.UserData==null)
            {
                return View("Index");
            }
            _service.CreateUser(u);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditUser(int Id)
        {
            var GetById = _service.GetUserById(Id);
            return View("Index",GetById);
        }
        public async Task<IActionResult> DeleteUser(int Id)
        {
            if (Id != null)
            {
                _service.DeleteById(Id);
               
            }

            return RedirectToAction("Index");

        }
    }
}
