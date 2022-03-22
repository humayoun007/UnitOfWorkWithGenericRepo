using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace TestProject
{
    public class Startup
    {
        //IConfigurationRoot ConfigurationRoot { get; }
        IConfiguration Configuration { get; set; }
      
        public Startup()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //ConfigurationRoot = builder.Build();
            this.Configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app)
        {
        }

        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<INotifier, Notifier>();
            //services.AddDbContext<ApplicationDataContext>(opt => opt
            //.UseSqlServer(ConfigurationRoot.GetSection("ConnectionStrings:WebApiDatabase").Value));
            services.AddDbContext<ApplicationDataContext>(opt => opt
            .UseSqlServer(Configuration.GetConnectionString("WebApiDatabase")));
        }
    }
}