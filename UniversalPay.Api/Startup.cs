using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using UniversalPay.Api.Auth;
using UniversalPay.Api.Controllers;
using UniversalPay.Database;
using UniversalPay.Domain.Entities;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
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
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddScoped<LoginServiceApi>();
            services.AddScoped<SigningConfigurations>();
            services.AddScoped<TokenConfigurations>();

            services.AddScoped<User>();

            services.AddControllers(options =>
                     options.Filters.Add(new HttpResponseExceptionFilter()));

            services.AddJwtConfigWebApi(Configuration);

            var assembly = AppDomain.CurrentDomain.Load("UniversalPay.Application");
            services.AddMediatR(assembly);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentAccount, PaymentAccount>();
                cfg.CreateMap<PaymentAccount, PaymentAccount>();
            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniversalPay.Api", Version = "v1" });
                c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
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
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

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
