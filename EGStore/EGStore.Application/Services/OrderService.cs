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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }
        public bool AddOrder(OrderDTO orderDTO)
        {
            orderDTO.CreateDay = DateTime.Now;
            orderDTO.UpdateDay = DateTime.Now;
            return _orderRepo.Add(_mapper.Map<Order>(orderDTO));
        }

        public List<OrderDTO> GetAllOrders()
        {
            return _mapper.Map<List<OrderDTO>>(_orderRepo.GetAll());
        }

        public OrderDTO GetOrderById(Guid id)
        {
            return _mapper.Map<OrderDTO>(_orderRepo.Get(id));
        }

        public bool UpdateOrder(OrderDTO orderDTO)
        {
            return _orderRepo.Update(_mapper.Map<Order>(orderDTO));
        }

        public bool DeleteOrder(Guid id)
        {
            return _orderRepo.Delete(id);
        }
    }
}
