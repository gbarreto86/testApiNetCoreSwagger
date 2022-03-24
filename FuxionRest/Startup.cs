using ApiFuxion.Custom;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Application.Main.Services.MaestroModule;
using System.Domain.Interfaces.MaestroModule;
using System.Infrastructure.Tools.Configuration;
using System.IO;
using System.Persistence.Core;
using System.Persistence.Data.MaestroModule.Repositories;
//using System.Persitence.Service.Exigo;
//using System.Persitence.Service.Exigo.Repositories;
using System.Reflection;
using System.Text;

namespace ApiBackFuxion
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

            services.AddAutoMapper();

            services.AddTransient<IConnectionBase, ConnectionBase>();
            
            services.AddTransient<System.Application.Main.Services.MaestroModule.IMaestroService, MaestroService>();
            services.AddTransient<IMaestroRepository, MaestroRepository>();
            
            //JWT
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);


            var appSettings = appSettingsSection.Get<AppSettings>();
            var secret = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Search", new OpenApiInfo {  Title = "Consulta de Servicio", Version = "v1" });
                c.SwaggerDoc("Security", new OpenApiInfo { Title = "Servicio de Security", Version = "v1" });

                c.CustomOperationIds(apiDesc =>
                {
                    return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
                });

                c.EnableAnnotations();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
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
                        Array.Empty<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt => {

                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //ValidateLifetime = true,
                    //ClockSkew = TimeSpan.Zero
                };

            });

            services.AddScoped<IToken, Token>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
                c.RouteTemplate = "{documentName}.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "API SERVICE"; 
                c.DefaultModelRendering(ModelRendering.Example);
                c.DocExpansion(DocExpansion.None);
                //c.SupportedSubmitMethods(new SubmitMethod[] { 0 });//Bloquea los metodos post
                c.SwaggerEndpoint("/Search.json", "Search");
                c.SwaggerEndpoint("/Security.json", "Security");
                //c.SwaggerEndpoint("/Penny.json", "API Fuxion Penny");
                c.RoutePrefix = string.Empty;
            });

        }
    }
}
