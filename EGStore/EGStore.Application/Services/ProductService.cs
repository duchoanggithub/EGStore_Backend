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
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public bool AddProduct(ProductDTO productDTO)
        {
            productDTO.CreateDay = DateTime.Now;
            productDTO.UpdateDay = DateTime.Now;
            return _productRepo.Add(_mapper.Map<Product>(productDTO));
        }

        public List<ProductDTO> GetAllProducts()
        {
            return _mapper.Map<List<ProductDTO>>(_productRepo.GetAll());
        }

        public List<ProductDTO> GetProductsByCategoryId(Guid categoryId)
        {
            var products = _productRepo.GetAll().Where(p => p.CategoryId == categoryId).ToList();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public List<ProductDTO> GetProductsBySupId(Guid supId)
        {
            var products = _productRepo.GetAll().Where(p => p.SupId == supId).ToList();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public ProductDTO GetProductById(Guid id)
        {
            return _mapper.Map<ProductDTO>(_productRepo.Get(id));
        }

        public List<ProductDTO> SearchProducts(string keyword)
        {
            var products = _productRepo.GetAll()
            .Where(p => p.ProdName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            p.Describe.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            return _mapper.Map<List<ProductDTO>>(products);
        }
        public bool UpdateProduct(ProductDTO productDTO)
        {
            return _productRepo.Update(_mapper.Map<Product>(productDTO));
        }

        public bool DeleteProduct(Guid id)
        {
            return _productRepo.Delete(id);
        }
    }
}
