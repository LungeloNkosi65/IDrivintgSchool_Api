using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Implementations;
using Repository.Interfaces;
using Services.Implementations;
using Services.Interfaces;
using Models;
using Microsoft.EntityFrameworkCore;
using DrivingSchool_Api;
using BuisinessLogic.Implementations;
using BuisinessLogic.Interfaces;

namespace DrivingSchoolBackOffice
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
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            //services.AddSwaggerGen();
            services.AddControllersWithViews();
            NewMethod(services);
            services.AddScoped<IGenericRepository<TimeSlot>, TimeSlotRepository>();
            services.AddScoped<ITimeSlotService, TimeSlotService>();
            services.AddScoped(typeof(IErrorMessageService<>), typeof(ErrorMessageService<>));
            services.AddScoped<IDapperBaseRepository, DapperBaseRepository>();
            services.AddScoped<IBookingPackageRepository, BookingPackageRepository>();
            services.AddScoped<IBookingPackageService, BookingPackageService>();
            services.AddScoped<IBookingTypeRepository, BookingTypeRepository>();
            services.AddScoped<IBookingTypeService, BookingTypeService>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IPackageInclusionRepository, PackageInclusionRepository>();
            services.AddScoped<IPackageInclusionService, PackageInclusionService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationLogic, AuthenticationLogic>();
            services.AddScoped<IBusinessLogicUnitOfWork, BusinessLogicUnitOfWork>();
            services.AddScoped<IServicesUnitOfWork, ServicesUnitOfWork>();
        }

        private void NewMethod(IServiceCollection services)
        {
            services.AddDbContext<DrivingSchoolDbContext>(options =>
                                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
