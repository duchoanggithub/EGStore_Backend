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
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepo _orderProductRepo;
        private readonly IMapper _mapper;
        public OrderProductService(IOrderProductRepo orderProductRepo, IMapper mapper)
        {
            _orderProductRepo = orderProductRepo;
            _mapper = mapper;
        }
        public bool AddOrderProduct(OrderProductDTO orderProductDTO)
        {
            orderProductDTO.CreateDay = DateTime.Now;
            orderProductDTO.UpdateDay = DateTime.Now;
            return _orderProductRepo.Add(_mapper.Map<OrderProduct>(orderProductDTO));
        }

        public List<OrderProductDTO> GetAllOrderProducts()
        {
            return _mapper.Map<List<OrderProductDTO>>(_orderProductRepo.GetAll());
        }

        public OrderProductDTO GetOrderProductById(Guid id)
        {
            return _mapper.Map<OrderProductDTO>(_orderProductRepo.Get(id));
        }

        public bool UpdateOrderProduct(OrderProductDTO orderProductDTO)
        {
            return _orderProductRepo.Update(_mapper.Map<OrderProduct>(orderProductDTO));
        }

        public bool DeleteOrderProduct(Guid id)
        {
            return _orderProductRepo.Delete(id);
        }
    }
}
