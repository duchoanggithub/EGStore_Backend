﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Domain.Entities;
using EGStore.Domain.Repositories;
using EGStore.Infrastructure.Context;

namespace EGStore.Infrastructure.Repositories
{
    public class RoleRepo : Repo<Role>, IRoleRepo
    {
        public RoleRepo(EGStoreContext context) : base(context) { }
    }
}