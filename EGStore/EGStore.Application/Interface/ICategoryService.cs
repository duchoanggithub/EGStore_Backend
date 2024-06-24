using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetAllCategorys();
        CategoryDTO GetCategoryById(Guid id);
        bool AddCategory(CategoryDTO categoryDTO);
        bool UpdateCategory(CategoryDTO categoryDTO);
        bool DeleteCategory(Guid id);
    }
}
