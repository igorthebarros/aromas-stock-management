using Aromas.App.Interface;
using Aromas.App.Services;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Domain.Interfaces.Services;
using Aromas.Domain.Services;
using Aromas.Infra.Data.Context;
using Aromas.Infra.Data.Repositories;
using Aromas.MVC.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aromas.WebApp
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
            services.AddCors(
                options =>
                {
                    options.AddPolicy("CorsPolicy", builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                }
            );

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase("connectionString")
            );

            services.AddControllersWithViews();

            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<UserMapperProfile>();
                config.AddProfile<ProductMapperProfile>();
                config.AddProfile<CategoryMapperProfile>();
            });
            IMapper mapper = autoMapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddTransient<IUserAppService, UserAppService>();

            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient<IUserService, UserService>();


            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();

            //TODO: Remove razor dependencies when Angular is added
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

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
