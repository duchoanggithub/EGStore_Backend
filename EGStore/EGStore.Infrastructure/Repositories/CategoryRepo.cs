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
    public class CategoryRepo : Repo<Category>, ICategoryRepo
    {
        public CategoryRepo(EGStoreContext context) : base(context) { }
    }
}
