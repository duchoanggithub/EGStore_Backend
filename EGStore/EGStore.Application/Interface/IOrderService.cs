using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface IOrderService
    {
        List<OrderDTO> GetAllOrders();
        OrderDTO GetOrderById(Guid id);
        bool AddOrder(OrderDTO orderDTO);
        bool UpdateOrder(OrderDTO orderDTO);
        bool DeleteOrder(Guid id);
    }
}
