using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RecipeApp.Data;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RecipeApp.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.Net.Http.Headers;

namespace RecipesApi

{
  public class Startup
  {

    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      _env = env;
      _configuration = configuration;

    }



    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      var appSettingsSection = _configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettingsSection);

      // configure jwt authentification
      
      
      var appSettings = appSettingsSection.Get<AppSettings>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(x =>
      {
        x.Events = new JwtBearerEvents
        {
          OnTokenValidated = context =>
          {
            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
            var userId = int.Parse(context.Principal.Identity.Name);
            var user = userService.GetById(userId);
            if (user == null)
            {
              // return unauthorized if user no longer exists
              context.Fail("Unauthorized");
            }
            return Task.CompletedTask;
          }
        };
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddScoped<IUserService, UserService>();
      services.AddDbContext<RecipesContext>(options =>
      {
        options.UseSqlServer(_configuration.GetConnectionString("WebApiDatabase"));
      });

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecipesApi", Version = "v1" });


        c.AddSecurityDefinition(
                   "token",
                   new OpenApiSecurityScheme
                   {
                     Type = SecuritySchemeType.Http,
                     BearerFormat = "JWT",
                     Scheme = "Bearer",
                     In = ParameterLocation.Header,
                     Name = HeaderNames.Authorization
                   }
               );

        c.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "token"
                                    },
                                },
                                Array.Empty<string>()
                            }
            }
        );





      });
      services.AddSwaggerGenNewtonsoftSupport();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecipesApi v1"));
        app.UseStatusCodePages();
      }
      app.UseHttpsRedirection();


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
