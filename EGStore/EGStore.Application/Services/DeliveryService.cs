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
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepo _deliveryRepo;
        private readonly IMapper _mapper;
        public DeliveryService(IDeliveryRepo deliveryRepo, IMapper mapper)
        {
            _deliveryRepo = deliveryRepo;
            _mapper = mapper;
        }

        public bool AddDelivery(DeliveryDTO deliveryDTO)
        {
            deliveryDTO.CreateDay = DateTime.Now;
            deliveryDTO.UpdateDay = DateTime.Now;
            return _deliveryRepo.Add(_mapper.Map<Delivery>(deliveryDTO));
        }

        public bool DeleteDelivery(Guid id)
        {
            return _deliveryRepo.Delete(id);
        }

        public List<DeliveryDTO> GetAllDeliverys()
        {
            return _mapper.Map<List<DeliveryDTO>>(_deliveryRepo.GetAll());
        }

        public DeliveryDTO GetDeliveryById(Guid id)
        {
            return _mapper.Map<DeliveryDTO>(_deliveryRepo.Get(id));
        }

        public bool UpdateDelivery(DeliveryDTO deliveryDTO)
        {
            return _deliveryRepo.Update(_mapper.Map<Delivery>(deliveryDTO));
        }
    }
}
