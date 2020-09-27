using BuisinessLogic.Implementations;
using BuisinessLogic.Interfaces;
using DrivingSchool_Api.GenericValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository.Implementations;
using Repository.Interfaces;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool_Api.Extensions
{
    public static class ServiceExtension
    {
        public static void Jwt(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Options => {
                Options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:56384",
                    ValidAudience = "http://localhost:56384",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                                                                                       
                };
            });
        } 

        public static void Dependancies(this IServiceCollection services)
        {
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
            services.AddScoped<IAuthenticationLogic, AuthenticationLogic>();
            services.AddScoped<ITokenBsLogic, TokenBsLogic>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ItokenService, TokenService>();
            services.AddScoped<ModelValidationAttribute>();
            services.AddScoped<ICryptoHelper, CryptoHelperBsLogic>();
            services.AddScoped<IBusinessLogicUnitOfWork, BusinessLogicUnitOfWork>();
            services.AddScoped<IServicesUnitOfWork, ServicesUnitOfWork>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }


    }
}
