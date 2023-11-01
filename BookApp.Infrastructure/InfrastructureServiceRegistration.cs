using BookApp.Application.Interface;
using BookApp.Application.Models;
using BookApp.Infrastructure.Mail;
using BookApp.Infrastructure.Persistence;
using BookApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            string dbConnectionString = config.GetConnectionString("DefaultConnection");

            var key = config.GetSection("SmtpSettings")
                    .GetSection("APIKey").Value;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    dbConnectionString,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));




            services.AddScoped<IAuthService, AuthenticationService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IEncryptService, EncryptService>();

            services.AddScoped<IUserService, UserService>();
          

            services.AddSendGrid(option =>
            {
                option.ApiKey = config.GetSection("SmtpSettings")
                    .GetSection("APIKey").Value;
            });
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookHistoryService, BookHistoryService>();
            services.AddScoped<IContextAccessor, ContextAccessor>();
            
            return services;
        }

    }
}
