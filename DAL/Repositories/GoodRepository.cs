﻿using DAL.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GoodRepository : GenericRepository<Good>
    {
        public GoodRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
