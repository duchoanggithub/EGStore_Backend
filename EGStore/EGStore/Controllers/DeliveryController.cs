using EGStore.Application.DTO;
using EGStore.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        /// <summary>
        /// thêm mới Delivery
        /// </summary>
        // <param name="deliveryDTO"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpPost("Them")]
        public IActionResult AddDelivery(DeliveryDTO deliveryDTO)
        {
            deliveryDTO.Id = Guid.NewGuid();
            if (_deliveryService.AddDelivery(deliveryDTO))
            {
                return Conflict("DV chuyển phát này đã tồn tại");
            }
            return Ok(new { Message = "Thêm DV chuyển phát thành công", deliveryDTO });

        }

        /// <summary>
        /// lấy theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("LayTatCa")]
        public IActionResult GetAllDeliverys()
        {

            return Ok(_deliveryService.GetAllDeliverys());
        }

        /// <summary>
        /// tìm theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("TimKiem/{id:Guid}")]
        public IActionResult GetDelivery(Guid id)
        {
            var nccs = _deliveryService.GetDeliveryById(id);
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
        [Authorize(Roles = "Admin")]
        [HttpPut("CapNhat/{id}")]
        public IActionResult UpdateDelivery(Guid id, DeliveryDTO deliveryDTO)
        {
    
            if (_deliveryService.UpdateDelivery(deliveryDTO))
            {
                return Ok(new { message = "Cập nhật thành công.", deliveryDTO});
            }

            return NotFound(new { message = "Không tìm thấy DV chuyển phát để cập nhật." });
        }

        /// <summary>
        /// xóa theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpDelete("Xoa/{id:Guid}")]
        public IActionResult DeleteDelivery(Guid id)
        {
            if (_deliveryService.DeleteDelivery(id))
            {
                return Ok(new { message = "Xóa thành công.", id });
            }

            return NotFound(new { message = "Không thể xóa DV chuyển phát " });
        }
    }
}
