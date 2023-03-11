using CrudeApp.Data.Services;
using CrudeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudeApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderServices _orderService;
        public OrdersController(IOrderServices orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> Order()
         {
            var data = await _orderService.GetAllOrder();
            if (data != null)
            {
                loadData();
                return View(data);
            }
            else
            {
                throw new ArgumentNullException(nameof(data));
            }


        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([Bind(include: "UserOrder")] OrderDto U)
        {

            ModelState.Remove("OrderList");
            if (!ModelState.IsValid)
            {
                loadData();
                var data = await _orderService.GetAllOrder();

                return View("Order", data);
            }
            _orderService.CreateUserOrder(U);
            return RedirectToAction("Order");
        }

        public async Task<IActionResult> EditOrder(int Id)
        {
            if (Id != null || Id != 0)
            {

                var GetById = _orderService.GetOrderById(Id);
                if (GetById != null)
                {
                    loadData();
                    return View("Order", GetById);
                }
                else
                {
                    throw new ArgumentNullException(nameof(GetById));
                }

            }
            else
            {
                throw new ArgumentNullException(nameof(Id));

            }

        }

        public async Task<IActionResult> DeleteOrder(int Id)
        {
            if (Id != 0)
            {
                _orderService.DeleteById(Id);
                return RedirectToAction("Order");
            }
            else
            {
                throw new ArgumentNullException(nameof(Id));
            }



        }



        private void loadData()
        {
            
              List<User> UserList=  _orderService.loadData();
            ViewBag.UserList = new SelectList(UserList, "Id", "UserName");


            
        }


    }
}
