using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface IOrderProductService
    {
        List<OrderProductDTO> GetAllOrderProducts();
        OrderProductDTO GetOrderProductById(Guid id);
        bool AddOrderProduct(OrderProductDTO orderProductDTO);
        bool UpdateOrderProduct(OrderProductDTO orderProductDTO);
        bool DeleteOrderProduct(Guid id);
    }
}
