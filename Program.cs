using QHRM_Assignment.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace QHRM_Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register the IProductRepository with the ProductRepository
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // Add Database Connection as Singleton
            builder.Services.AddSingleton<IDbConnection>(sp =>
                new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
     name: "default",
     pattern: "{controller=Products}/{action=Index}/{id?}");


            app.Run();

        }
    }
}
