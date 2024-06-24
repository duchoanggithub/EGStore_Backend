using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface ISupplierService
    {
        List<SupplierDTO> GetAllSuppliers();
        SupplierDTO GetSupplierById(Guid id);
        bool AddSupplier(SupplierDTO supplierDTO);
        bool UpdateSupplier(SupplierDTO supplierDTO);
        bool DeleteSupplier(Guid id);
    }
}
