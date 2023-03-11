using CrudeApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CrudeApp.Data.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly AppDbContext _context;
        public OrderServices(AppDbContext context)
        {
            _context = context;
        }

        public async void CreateUserOrder(OrderDto UserOrder)
        {
            try
            {

                if (UserOrder.UserOrder.Id > 0)
                {
                    _context.Entry(UserOrder.UserOrder).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                else
                {
                    await _context.Orders.AddAsync(UserOrder.UserOrder);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteById(int Id)
        {
            try
            {
                var SingleOrder = _context.Orders.Find(Id);
                if (SingleOrder != null)
                {
                    _context.Orders.Remove(SingleOrder);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<OrderDto> GetAllOrder()
        {
            try
            {
                var UserOrders = new OrderDto()
                {
                    OrderList = _context.Orders.ToList()

                };
               
             
                return UserOrders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public OrderDto GetOrderById(int Id)
        {
            try
            {
                if (Id != null || Id != 0)
                {

                    var OrderData = new OrderDto()
                    {
                        OrderList = _context.Orders.ToList(),
                        UserOrder = _context.Orders.FirstOrDefault(x => x.Id == Id)
                    };
                    return OrderData;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<User> loadData()
        {
            return _context.Users.ToList();
        }

    }
}
