using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategories;
using ShopManagement.Application.Contracts.Products;
using ShopManagement.Application.Contracts.ProdutPictures;
using ShopManagement.Application.Contracts.Slides;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictuerAgg;
using ShopManagement.Domain.SliderAgg;
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
        public static void Configuration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPoductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<ISlideRepository, SlideRepositorycs>();
            services.AddTransient<ISlideApplication, SlideApplciation>();
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(configuration.GetConnectionString("defaultConnection")));


        }

    }
}
