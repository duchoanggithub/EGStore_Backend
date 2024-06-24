using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface IDeliveryService
    {
        List<DeliveryDTO> GetAllDeliverys();
        DeliveryDTO GetDeliveryById(Guid id);
        bool AddDelivery(DeliveryDTO deliveryDTO);
        bool UpdateDelivery(DeliveryDTO deliveryDTO);
        bool DeleteDelivery(Guid id);
    }
}
