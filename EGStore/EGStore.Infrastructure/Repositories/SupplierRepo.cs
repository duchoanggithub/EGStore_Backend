using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Domain.Entities;
using EGStore.Domain.Repositories;
using EGStore.Infrastructure.Context;

namespace EGStore.Infrastructure.Repositories
{
    public class SupplierRepo : Repo<Supplier>, ISupplierRepo
    {
        public SupplierRepo(EGStoreContext context) : base(context) { }
    }
}
