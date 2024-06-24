using EGStore.Application.DTO;
using EGStore.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        /// <summary>
        /// thêm mới supplier
        /// </summary>
        // <param name="SupplierDTO"></param>
        /// <returns></returns>
        /// 
        [HttpPost("Them")]
        public IActionResult AddSupplier(SupplierDTO supplierDTO)
        {
            supplierDTO.Id = Guid.NewGuid();
            if (_supplierService.AddSupplier(supplierDTO))
            {
            return Conflict("nhà cung cấp này đã tồn tại");

            }
            return Ok(new { Message = "Thêm nhà cung cấp thành công", supplierDTO });
        }

        /// <summary>
        /// lấy theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("LayTatCa")]
        public IActionResult GetAllSuppliers()
        {

            return Ok(_supplierService.GetAllSuppliers());
        }

        /// <summary>
        /// tìm theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("TimKiem/{id:Guid}")]
        public IActionResult GetSupplier(Guid id)
        {
            var nccs = _supplierService.GetSupplierById(id);
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
        public IActionResult UpdateSupplier(Guid id, SupplierDTO supplierDTO)
        {
            if (_supplierService.UpdateSupplier(supplierDTO))
            {
                return Ok(new { Mesasge = "Cập nhật thành công", supplierDTO });
            }
            return NotFound(new { Mesasge = "Không tìm thấy nhà cung cấp để để cập nhật" });
        }

        /// <summary>
        /// xóa theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("Xoa/{id:Guid}")]
        public IActionResult DeleteSupplier(Guid id)
        {
            if (_supplierService.DeleteSupplier(id))
            {
                return Ok(new { message = "Xóa thành công.", id });
            }
            return NotFound(new { message = "Không thể xóa vì nhà cung cấp này không tồn tại." });
        }
    }
}

