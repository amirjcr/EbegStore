using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventories;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructuer.Bootstrapper
{
    public  class InventoryBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IInventoryRepository,InvenotryRepository>();
            services.AddTransient<IInventoryApplication, InventoryManagementApplication>();

            services.AddDbContext<InventoryDbContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
