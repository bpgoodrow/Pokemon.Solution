using JWTAuthentication.Authentication;  
using Microsoft.AspNetCore.Authentication.JwtBearer;  
using Microsoft.AspNetCore.Builder;  
using Microsoft.AspNetCore.Hosting;  
using Microsoft.AspNetCore.Identity;  
using Microsoft.EntityFrameworkCore;  
using Microsoft.Extensions.Configuration;  
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.Extensions.Hosting;  
using Microsoft.IdentityModel.Tokens;  
using System.Text;
using Pokedex.Models;
  
namespace JWTAuthentication  
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
            services.AddControllers();  
  
            // For Entity Framework  

            services.AddDbContext<PokedexContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
            services.AddControllers();
     
  
            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()  
                .AddEntityFrameworkStores<ApplicationDbContext>()  
                .AddDefaultTokenProviders(); 

            services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 0;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredUniqueChars = 0;
                });
  
            // Adding Authentication  
            services.AddAuthentication(options =>  
            {  
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;  
            })  
  
            // Adding Jwt Bearer  
            .AddJwtBearer(options =>  
            {  
                options.SaveToken = true;  
                options.RequireHttpsMetadata = false;  
                options.TokenValidationParameters = new TokenValidationParameters()  
                {  
                    ValidateIssuer = true,  
                    ValidateAudience = true,  
                    ValidAudience = Configuration["JWT:ValidAudience"],  
                    ValidIssuer = Configuration["JWT:ValidIssuer"],  
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))  
                };  
            });  
        }  
  
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)  
        {  
            if (env.IsDevelopment())  
            {  
                app.UseDeveloperExceptionPage();  
            }  
  
            app.UseRouting();  
  
            app.UseAuthentication();  
            app.UseAuthorization();  
  
            app.UseEndpoints(endpoints =>  
            {  
                endpoints.MapControllers();  
            });  
        }  
    }  
}  