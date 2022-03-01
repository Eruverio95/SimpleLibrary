using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Library.Data;
using Library.Logic;
using Library.Logic.Interfaces;
using Library.Repository;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library
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
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddDbContext<LibraryDbContext>(
        opts => opts.UseSqlServer(Configuration.GetConnectionString("connLibrary")));
      services.AddAutoMapper();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info
        {
          Version = "v1",
          Title = "Library API .NET Core",
          Description = "Simple Library App",
          TermsOfService = "None",
          Contact = new Contact()
          {
            Name = "Mirosław Gąsior",
            Email = "miroslaw.gasior95@gmail.com",
            Url = "https://github.com/Eruverio95"
          }
        });
      });

      services
        .AddScoped<IAuthorizationService, AuthorizationService>()
        .AddScoped<IBookLogic, BookLogic>()
        .AddScoped<IUserLogic, UserLogic>()
        .AddTransient<IBookingRepository, BookingRepository>()
        .AddTransient<IBookRepository, BookRepository>()
        .AddTransient<IUserRepository, UserRepository>()
        .AddTransient<IUserRoleRepository, UserRoleRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
      app.UseSwagger();
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API v1"); });
    }
  }
}
