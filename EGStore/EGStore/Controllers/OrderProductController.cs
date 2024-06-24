using EGStore.Application.DTO;
using EGStore.Application.Interface;
using EGStore.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductService _orderproductService;
        public OrderProductController(IOrderProductService orderproductService)
        {
            _orderproductService = orderproductService;
        }

        /// <summary>
        /// thêm mới OrderProduct
        /// </summary>
        // <param name="OrderProductDTO"></param>
        /// <returns></returns>
        /// 
        [HttpPost("Them")]
        public IActionResult AddOrderProduct(OrderProductDTO orderProductDTO)
        {
            orderProductDTO.Id = Guid.NewGuid();
            if (_orderproductService.AddOrderProduct(orderProductDTO))
            {
                return Conflict("Đơn hàng sản phẩm này đã tồn tại");
            }
            return Ok(new { Message = "Thêm đơn hàng sản phẩm thành công", orderProductDTO });

        }

        /// <summary>
        /// lấy theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("LayTatCa")]
        public IActionResult GetAllOrderProducts()
        {

            return Ok(_orderproductService.GetAllOrderProducts());
        }

       

        /// <summary>
        /// tìm theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("TimKiem/{id:Guid}")]
        public IActionResult GetOrderProduct(Guid id)
        {
            var nccs = _orderproductService.GetOrderProductById(id);
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
        public IActionResult UpdateOrderProduct(Guid id, OrderProductDTO orderProductDTO)
        {
            if (_orderproductService.UpdateOrderProduct(orderProductDTO))
            {
                return Ok(new { message = "Cập nhật thành công.", orderProductDTO });
            }

            return NotFound(new { message = "Không tìm thấy đơn hàng sản phẩm để cập nhật." });
        }

        /// <summary>
        /// xóa theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("Xoa/{id:Guid}")]
        public IActionResult DeleteOrderProduct(Guid id)
        {
            if (_orderproductService.DeleteOrderProduct(id))
            {
                return Ok(new { message = "Xóa thành công.", id });
            }
            return NotFound(new { message = "Không thể xóa vì đơn hàng sản phẩm này không tồn tại." });
        }
    }
}

