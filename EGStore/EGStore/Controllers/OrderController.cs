using EGStore.Application.DTO;
using EGStore.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// thêm mới role
        /// </summary>
        // <param name="RoleDTO"></param>
        /// <returns></returns>
        /// 
        [HttpPost("Them")]
        public IActionResult AddOrder(OrderDTO orderDTO)
        {
            orderDTO.Id = Guid.NewGuid();
            if (_orderService.AddOrder(orderDTO))
            {
                return Conflict("đơn hàng này đã tồn tại");
            }
            return Ok(new { Message = "Thêm đơn hàng thành công", orderDTO });

        }

        /// <summary>
        /// lấy theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("LayTatCa")]
        public IActionResult GetAllOrders()
        {

            return Ok(_orderService.GetAllOrders());
        }

        /// <summary>
        /// tìm theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("TimKiem/{id:Guid}")]
        public IActionResult GetOrder(Guid id)
        {
            var nccs = _orderService.GetOrderById(id);
            if (nccs == null)
            {
                return NotFound();
            }
            return Ok(nccs);
        }

        /// <summary>
        /// cập nhật theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPut("CapNhat/{id}")]
        public IActionResult UpdateOrder(Guid id, OrderDTO orderDTO)
        {
            if (_orderService.UpdateOrder(orderDTO))
            {
                return Ok(new { message = "Cập nhật thành công.", orderDTO });
            }

            return NotFound(new { message = "Không tìm thấy đơn hàng để cập nhật." });
        }

        /// <summary>
        /// xóa theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("Xoa/{id:Guid}")]
        public IActionResult DeleteOrder(Guid id)
        {
            if (_orderService.DeleteOrder(id))
            {
                return Ok(new { message = "Xóa thành công.", id });
            }
            return NotFound(new { message = "Không thể xóa vì đơn hàng này không tồn tại." });
        }
    }
}

