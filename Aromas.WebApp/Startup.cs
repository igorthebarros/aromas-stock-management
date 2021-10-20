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
            services.AddTransient<ICategoryAppService, CategoryAppService>();
            services.AddTransient<IProductAppService, ProductAppService>();

            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

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
