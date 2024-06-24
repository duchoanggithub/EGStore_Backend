using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface IProductImgService
    {
        List<ProductImgDTO> GetAllProductImgs();
        ProductImgDTO GetProductImgById(Guid id);
        bool AddProductImg(ProductImgDTO productImgDTO);
        bool UpdateProductImg(ProductImgDTO productImgDTO);
        bool DeleteProductImg(Guid id);
    }
}
