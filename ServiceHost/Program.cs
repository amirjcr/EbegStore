using DiscountManagement.Infrastructure.Configuration;
using InventoryManagement.Infrastructuer.Bootstrapper;
using ShopManagement.Infrastructuer.Configuration;



var builder = WebApplication.CreateBuilder(args);



#region ShopBootstarper
ShopManagementBootstraper.Configuration(builder.Services, builder.Configuration);
#endregion
#region DiscountBootstrapper
DiscountManagementBootstraper.Configure(builder.Services, builder.Configuration.GetConnectionString("defaultConnection"));
#endregion

#region InventoryBootstrapper
InventoryBootstrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("defaultConnection"));
#endregion

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();

});


app.Run();
