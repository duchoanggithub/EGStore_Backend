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
    public class ProductImgService : IProductImgService
    {
        private readonly IProductImgRepo _productImgRepo;
        private readonly IMapper _mapper;
        public ProductImgService(IProductImgRepo productImgRepo, IMapper mapper)
        {
            _productImgRepo = productImgRepo;
            _mapper = mapper;
        }
        public bool AddProductImg(ProductImgDTO productImgDTO)
        {
            return _productImgRepo.Add(_mapper.Map<ProductImg>(productImgDTO));
        }

        public List<ProductImgDTO> GetAllProductImgs()
        {
            return _mapper.Map<List<ProductImgDTO>>(_productImgRepo.GetAll());
        }

        public ProductImgDTO GetProductImgById(Guid id)
        {
            return _mapper.Map<ProductImgDTO>(_productImgRepo.Get(id));
        }

        public bool UpdateProductImg(ProductImgDTO productImgDTO)
        {
            return _productImgRepo.Update(_mapper.Map<ProductImg>(productImgDTO));
        }

        public bool DeleteProductImg(Guid id)
        {
            return _productImgRepo.Delete(id);
        }
    }
}
