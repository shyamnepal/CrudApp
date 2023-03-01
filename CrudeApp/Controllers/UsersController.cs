using CrudeApp.Data.Services;
using CrudeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

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
            if (data != null)
            {
                return View(data);
            }
            else
            {
                throw new ArgumentNullException(nameof(data));
            }

           
        }

       
      
       
        [HttpPost]
        public async Task<IActionResult> Create([Bind(include:"UserData")] UserDto u)
        {
            
            ModelState.Remove("UserList");
            if (!ModelState.IsValid)
            {
                var data = await _service.GetAll();

                return View("Index",data);
            }
            _service.CreateUser(u);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditUser(int Id)
        {
            if (Id != null || Id !=0)
            {
                
                var GetById = _service.GetUserById(Id);
                if (GetById != null)
                {
                    return View("Index", GetById);
                }
                else
                {
                    throw new ArgumentNullException(nameof(GetById));
                }
               
            }else
            {
                throw new ArgumentNullException(nameof(Id));
                
            }
            
        }
        public async Task<IActionResult> DeleteUser(int Id)
        {
            if (Id != 0)
            {
                _service.DeleteById(Id);
                return RedirectToAction("Index");
            }
            else
            {
                throw new ArgumentNullException(nameof(Id));
            }

           

        }
    }
}
