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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepo _supplierRepo;
        private readonly IMapper _mapper;
        public SupplierService(ISupplierRepo supplierRepo, IMapper mapper)
        {
            _supplierRepo = supplierRepo;
            _mapper = mapper;
        }
        public bool AddSupplier(SupplierDTO supplierDTO)
        {
            supplierDTO.CreateDay = DateTime.Now;
            supplierDTO.UpdateDay = DateTime.Now;
            return _supplierRepo.Add(_mapper.Map<Supplier>(supplierDTO));
        }

        public List<SupplierDTO> GetAllSuppliers()
        {
            return _mapper.Map<List<SupplierDTO>>(_supplierRepo.GetAll());
        }

        public SupplierDTO GetSupplierById(Guid id)
        {
            return _mapper.Map<SupplierDTO>(_supplierRepo.Get(id));
        }

        public bool UpdateSupplier(SupplierDTO supplierDTO)
        {
            return _supplierRepo.Update(_mapper.Map<Supplier>(supplierDTO));
        }

        public bool DeleteSupplier(Guid id)
        {
            return _supplierRepo.Delete(id);
        }
    }
}
