using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXiecheng.API.Database;
using FakeXiecheng.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace FakeXiecheng.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) 
        { 
            Configuration = configuration; 
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //注入MVC的服务依赖 
            services.AddControllers();
            //services.AddTransient<ITouristRouteRepository, MockTouristRouteRepository>(); //注册路线仓库的依赖注入
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>(); //注册路线仓库的依赖注入
            services.AddDbContext<AppDbContext>(option => {
                //option.UseSqlServer("Data Source=LocalHost;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); 
                option.UseSqlServer(Configuration["DbContext:ConnectionString"]);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllers();  
            });
        }
    }
}
