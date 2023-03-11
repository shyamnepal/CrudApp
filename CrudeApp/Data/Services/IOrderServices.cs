using CrudeApp.Models;

namespace CrudeApp.Data.Services
{
    public interface IOrderServices
    {
        Task<OrderDto> GetAllOrder();
        void CreateUserOrder(OrderDto UserOrder);
        List<User> loadData();
        OrderDto GetOrderById(int Id);
        void DeleteById(int Id);
    }
}
