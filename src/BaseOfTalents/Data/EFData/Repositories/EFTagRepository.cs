﻿using Data.Infrastructure;
using Domain.Entities.Enum.Setup;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EFData.Repositories
{
    public class EFTagRepository : EFBaseEntityRepository<Tag>, ITagRepository
    {
        public EFTagRepository(IDbFactory factory) : base(factory)
        {

        }
    }
}