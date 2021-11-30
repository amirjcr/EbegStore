using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategories;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructuer.EFCore;
using ShopManagement.Infrastructuer.EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructuer.Configuration
{
    public class ShopManagementBootstraper
    {
        public static void Configuration(IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<IPoductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(configuration.GetConnectionString("defaultConnection"))); 

        }

    }
}
