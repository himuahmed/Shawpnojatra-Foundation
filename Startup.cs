using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shawpnojatra_Foundation.Models;
using Shawpnojatra_Foundation.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Shawpnojatra_Foundation
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
            services.AddDbContext<ApplicationContext>(options =>
                      options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"))
                  );
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddTransient<IActivityService, ActivityService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddHttpContextAccessor();
            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 6;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredUniqueChars = 0;
                option.SignIn.RequireConfirmedEmail = false;
            });
          

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AuthSetting:tokenKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };

            });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = Configuration["ApplicationSettings:LoginPath"];
                config.AccessDeniedPath = Configuration["ApplicationSettings:LoginPath"];
            });
            services.AddAuthentication().AddCookie();
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Activity}/{action=Index}/{id?}");
            });
        }
    }
}
