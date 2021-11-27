using Aromas.App.Interface;
using Aromas.App.Services;
using Aromas.Domain.Interfaces.Repositories;
using Aromas.Domain.Interfaces.Services;
using Aromas.Domain.Services;
using Aromas.Infra.Data.Context;
using Aromas.Infra.Data.Repositories;
using Aromas.MVC.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            var key = Encoding.ASCII.GetBytes(Domain.Settings.TokenSetting.Secret);

            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(b =>
                {
                    b.RequireHttpsMetadata = false;
                    b.SaveToken = true;
                    b.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

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
                options => options.UseSqlServer(Configuration.GetConnectionString("Azure"))
            );

            services.AddControllersWithViews();

            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<UserMapperProfile>();
                config.AddProfile<ProductMapperProfile>();
                config.AddProfile<CategoryMapperProfile>();
                config.AddProfile<PolicyMapperProfile>();

            });

            IMapper mapper = autoMapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<ICategoryAppService, CategoryAppService>();
            services.AddTransient<IProductAppService, ProductAppService>();
<<<<<<< HEAD
            services.AddTransient<ITokenAppService, TokenAppService>();
=======
            services.AddTransient<IPolicyAppService, PolicyAppService>();
>>>>>>> 663adf015ad48e53a9cbb14599b5386a7b6c6d4a

            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
<<<<<<< HEAD
            services.AddTransient<ITokenService, TokenService>();
=======
            services.AddTransient<IPolicyService, PolicyService>();
>>>>>>> 663adf015ad48e53a9cbb14599b5386a7b6c6d4a

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();

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
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
