using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using UniversalPay.Database;
using UniversalPay.Database.Repositories.Contracts;
using UniversalPay.Domain.Dtos;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<UniversalPayContext>();
            services.AddScoped<IPaymentAccountRepositoy, PaymentAccountRepositoy>();
            services.AddScoped<IPaymentRepositoy, PaymentRepositoy>();
            services.AddScoped<IClientRepositoy, ClientRepositoy>();

            services.AddControllers();

            var assembly = AppDomain.CurrentDomain.Load("UniversalPay.Application");
            services.AddMediatR(assembly);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentAccountDto, PaymentAccount>();
                cfg.CreateMap<PaymentAccount, PaymentAccountDto>();
            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniversalPay.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniversalPay.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
