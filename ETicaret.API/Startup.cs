using eTicaret.DataAccsess;
using eTicaret.DataAccsess.Abstract;
using eTicaret.DataAccsess.Concrete;
using ETicaret.Business.Abstract;
using ETicaret.Business.AutoMapperProfile;
using ETicaret.Business.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.API
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                         .AddJwtBearer(options => {
                             options.TokenValidationParameters = new TokenValidationParameters
                             {
                                 ValidateIssuer = true,
                                 ValidateAudience = true,
                                 ValidateLifetime = true,
                                 ValidateIssuerSigningKey = true,
                                 ValidIssuer = Configuration["Jwt:Issuer"],
                                 ValidAudience = Configuration["Jwt:Audience"],
                                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                             };
                         });
            services.AddAuthorization(x =>
            {
                x.AddPolicy("CustomerAndAdmin", policy => 
                 policy.RequireRole("customer","admin"));

                x.AddPolicy("Customer", policy =>
                 policy.RequireRole("customer"));

                x.AddPolicy("Admin", policy =>
                policy.RequireRole("admin"));

                x.AddPolicy("Company", policy =>
                 policy.RequireRole("company"));

                x.AddPolicy("CompanyAndAdmin", policy =>
                 policy.RequireRole("company", "admin"));

                x.AddPolicy("Shopping", policy =>
                 policy.RequireRole("company", "admin","customer"));

            });
            services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
            });
            services.AddMvc();
            services.AddControllers();
            services.AddDbContext<ETicaretDbContext>();
            services.AddScoped<IETicaretService, ETicaretManager>();
            services.AddScoped<IETicaretRepository, ETicaretRepository>();
            services.AddAutoMapper(typeof(ETicaretMapProfile));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ETicaret.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Bearer yazýp bir boþluk býrakýn, ardýndan Token'i girin."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                    }
                });
            });

            //services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ETicaret.API v1"));
                
            }
            
            app.UseHttpsRedirection();
            app.UseRouting();

           
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseResponseWrapper();

            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvc(_ => _.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}"));
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
            
        }
    }
}
