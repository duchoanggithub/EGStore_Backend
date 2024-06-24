using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface IProductService
    {
        List<ProductDTO> GetAllProducts();
        List<ProductDTO> GetProductsByCategoryId(Guid categoryId);
        List<ProductDTO> GetProductsBySupId(Guid supId);
        ProductDTO GetProductById(Guid id);
        List<ProductDTO> SearchProducts(string keyword);
        bool AddProduct(ProductDTO productDTO);
        bool UpdateProduct(ProductDTO productDTO);
        bool DeleteProduct(Guid id);
    }
}
