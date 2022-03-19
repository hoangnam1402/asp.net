using BackEnd.Data;
using ClassLibrary.Interface;
using ClassLibrary.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClassLibrary
{
    public static class ServiceRegister
    {
        public static void AddDataAccessorLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<ICustomerClass, ClassCustomer>();
            services.AddTransient<ICategoryClass, ClassCategory>();
            services.AddTransient<IProductClass, ClassProduct>();
            services.AddTransient<IOrderClass, ClassOrder>();
            services.AddTransient<IOrderItemClass, ClassOrderItem>();
            services.AddTransient<IProductRatingClass, ClassProductRating>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"), b =>
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));
        }
    }
}
