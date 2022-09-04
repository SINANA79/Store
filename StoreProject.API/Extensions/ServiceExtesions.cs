using Microsoft.EntityFrameworkCore;
using StoreProject.Infra.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.API.Extensions
{
    public static class ServiceExtesions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
    services.AddDbContext<StoreDbContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("StoreConnection"), b =>
            b.MigrationsAssembly("NewsBack.API")));
    }
}
