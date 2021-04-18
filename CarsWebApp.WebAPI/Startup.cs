using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CarsWebApp.BLL.Contracts;
using CarsWebApp.BLL.Implementation;
using CarsWebApp.DAL;
using CarsWebApp.DAL.Contracts;
using CarsWebApp.DAL.Implementations;

namespace CarsWebApp.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст MobileContext в качестве сервиса в приложение
            services.AddDbContext<AppContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            services.AddControllersWithViews();
            
            services.AddAutoMapper(typeof(Startup));
            
            //BLL
            services.Add(new ServiceDescriptor(typeof(ICityService), typeof(CityService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBuyerService), typeof(BuyerService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IDealerService), typeof(DealerService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICarService), typeof(CarService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IRequestService), typeof(RequestService), ServiceLifetime.Scoped));
            
            // DAL
            services.Add(new ServiceDescriptor(typeof(ICityDAL), typeof(CityDal), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBuyerDAL), typeof(BuyerDAL), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IDealerDAL), typeof(DealerDal), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICarDAL), typeof(CarDal), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IRequestDAL), typeof(RequestDal), ServiceLifetime.Scoped));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {    
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}