using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleSystem.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using SaleSystem.DAL.Implementation;
using SaleSystem.DAL.Interfaces;
using SaleSystem.BLL.Implementation;
using SaleSystem.BLL.Interfaces;

namespace SaleSystem.IOC
{
    public static class Dependency
    {
        public static void InjectDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Dbsale0014Context>(options => {
                options.UseSqlServer(configuration.GetConnectionString("SQLString"));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
