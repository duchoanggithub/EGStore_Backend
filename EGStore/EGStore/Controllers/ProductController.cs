using EGStore.Application.DTO;
using EGStore.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// thêm mới product
        /// </summary>
        // <param name="ProductDTO"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpPost("Them")]
        public IActionResult AddProduct(ProductDTO productDTO)
        {
            productDTO.GenerateProdCode(5);
            productDTO.Id = Guid.NewGuid();
            if (_productService.AddProduct(productDTO))
            {
                return Conflict("sản phẩm này đã tồn tại");
            }
            return Ok(new { Message = "Thêm sản phẩm thành công.", productDTO });
        }

        /// <summary>
        /// lấy theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("LayTatCa")]
        public IActionResult GetAllProducts()
        {

            return Ok(_productService.GetAllProducts());
        }

        /// <summary>
        /// lấy theo categoryId
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("LayTheoCategoryId/{categoryId}")]
        public IActionResult GetProductsByCategoryId(Guid categoryId)
        {
            var products = _productService.GetProductsByCategoryId(categoryId);
            if (products == null || !products.Any())
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cho CategoryId này." });
            }
            return Ok(products);
        }

        /// <summary>
        /// lấy theo supId
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("LayTheoSupId/{supId}")]
        public IActionResult GetProductsBySupId(Guid supId)
        {
            var products = _productService.GetProductsBySupId(supId);
            if (products == null || !products.Any())
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cho SupId này." });
            }
            return Ok(products);
        }

        /// <summary>
        /// tìm theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("TimKiem/{id:Guid}")]
        public IActionResult GetProduct(Guid id)
        {
            var nccs = _productService.GetProductById(id);
            if (nccs == null)
            {
                return NotFound();
            }
            return Ok(nccs);
        }

        [HttpGet("Search")]
        public IActionResult Search([FromQuery] string keyword)
        {
            var products = _productService.SearchProducts(keyword);
            if (products == null || !products.Any())
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm nào." });
            }
            return Ok(products);
        }

        /// <summary>
        /// cập nhật theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpPut("CapNhat/{id}")]
        public IActionResult UpdateProduct(Guid id, ProductDTO productDTO)
        {
            if (_productService.UpdateProduct(productDTO))
            {
                return Ok(new { message = "Cập nhật thành công.", productDTO });
            }

            return NotFound(new { message = "Không tìm thấy sản phẩm để cập nhật." });
        }

        /// <summary>
        /// xóa theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpDelete("Xoa/{id:Guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            if (_productService.DeleteProduct(id))
            {
                return Ok(new { message = "Xóa thành công.", id });
            }
            return NotFound(new { message = "Không thể xóa vì sản phẩm này không tồn tại." });
        }
    }
}

