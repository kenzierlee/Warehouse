using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Entities;

namespace Warehouse.Web.Models
{
    public class WarehouseWebContext : DbContext
    {
        public WarehouseWebContext (DbContextOptions<WarehouseWebContext> options)
            : base(options)
        {
        }

        public DbSet<Warehouse.Entities.Order> Order { get; set; }
    }
}
