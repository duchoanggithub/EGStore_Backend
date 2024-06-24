using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EGStore.Application.DTO;
using EGStore.Application.Interface;
using EGStore.Domain.Entities;
using EGStore.Domain.Repositories;

namespace EGStore.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo  _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public bool AddCategory(CategoryDTO categoryDTO)
        {
            categoryDTO.CreateDay = DateTime.Now;
            categoryDTO.UpdateDay = DateTime.Now;
            return _categoryRepo.Add(_mapper.Map<Category>(categoryDTO));
        }

        public List<CategoryDTO> GetAllCategorys()
        {
            return _mapper.Map<List<CategoryDTO>>(_categoryRepo.GetAll());
        }

        public CategoryDTO GetCategoryById(Guid id)
        {
            return _mapper.Map<CategoryDTO>(_categoryRepo.Get(id));
        }

        public bool UpdateCategory(CategoryDTO categoryDTO)
        {
            return _categoryRepo.Update(_mapper.Map<Category>(categoryDTO));
        }

        public bool DeleteCategory(Guid id)
        {
            return _categoryRepo.Delete(id);
        }
    }
}
