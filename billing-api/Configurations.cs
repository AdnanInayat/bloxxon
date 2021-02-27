using Bussiness.Services;
using Data;
using Data.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.API
{
    public class Configurations
    {
        public static void configureDependencies(IServiceCollection services)
        {
            
            services.AddScoped<DatabaseContext>();

            //Repos

            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IInvoiceRepo, InvoiceRepo>();
            services.AddScoped<IUserRepo, UserRepo>();

            //Serivces

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
