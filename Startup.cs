using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

using recruitmentmanagementsystem.ServiceLayer;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;
using recruitmentmanagementsystem.CommonModel;
using recruitmentmanagementsystem.MailServices;
using Microsoft.EntityFrameworkCore;
using recruitmentmanagementsystem.Data;
using Microsoft.AspNetCore.Identity;
using recruitmentmanagementsystem.CommonMethods;
using recruitmentmanagementsystem.AccountRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using recruitmentmanagementsystem.AuthecticationService;
using recruitmentmanagementsystem.RepositoryLayer;

namespace recruitmentmanagementsystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment Env)
        {
            Configuration = configuration;
            env = Env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            
            //mail setting
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            services.AddTransient<IAccountrepository, Accountrepository>();
            services.AddTransient<ICandidateService,CandidateService>();
            services.AddTransient<IRequisitionService,RequisitionService>();
            services.AddTransient<IRequisitionRepository, RequisitionRepository>();
            services.AddTransient<IResumeRepository, ResumeRepository>();
            services.AddTransient<IResumeService, ResumeService>();
            services.AddTransient<ICalendarRepository, CalanderRepository>();
            services.AddTransient<ICalendarService, CalendarService>();
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues=true;
                });
            //for herokku db
            var defaultConnectionString = string.Empty;

            if (env.IsDevelopment())
            {
                System.Diagnostics.Debug.WriteLine("this is developement modeeeee");
                defaultConnectionString = Configuration.GetConnectionString("recruitmentdb");
                
            }
            else
            {

                var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

                connectionUrl = connectionUrl.Replace("postgres://", string.Empty);
                var userPassSide = connectionUrl.Split("@")[0];
                var hostSide = connectionUrl.Split("@")[1];

                var user = userPassSide.Split(":")[0];
                var password = userPassSide.Split(":")[1];
                var host = hostSide.Split("/")[0];
                var server = host.Substring(0, host.Length - 5);
                var database = hostSide.Split("/")[1].Split("?")[0];

                defaultConnectionString = $"Server={server};Database={database};User Id={user};Password={password};Port=5432;sslmode=Require;Trust Server Certificate=true";
            }

            services.AddDbContext<Recruitmentcontext>(
                o => o.UseNpgsql(defaultConnectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<Recruitmentcontext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

                 .AddJwtBearer(option =>
                 {
                     option.SaveToken = true;
                     option.RequireHttpsMetadata =false;
                     option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ValidAudience =Configuration["jwt:ValidAudience"],
                         ValidIssuer=Configuration["jwt:ValidIssuer"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:Secret"]))
                     };

                 });
              
                  

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "recruitmentmanagementsystem", Version = "v1" });
                c.DescribeAllParametersInCamelCase();
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddTransient<ServiceLayer.IRequisitionService, ServiceLayer.RequisitionService>();
            services.AddTransient<ServiceLayer.IRequisitionService, ServiceLayer.RequisitionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "recruitmentmanagementsystem v1"));
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
