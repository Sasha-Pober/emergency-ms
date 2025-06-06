﻿using DotNetEnv;
using Infrastructure;
using Presentation;

namespace EmergencyMS.API
{
    public class Startup
    {
        readonly string AllowedOrigin = "allowedOrigin";

        private readonly IConfiguration _сonfiguration;

        public Startup(IWebHostEnvironment environment)
        {
            Env.Load("../../../../.env");
            _сonfiguration = new ConfigurationBuilder().AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", false, true).Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    );
            });

            services.ConfigureInfrastructure(_сonfiguration);
            services.ConfigurePresentation();
            services.AddControllers().AddApplicationPart(typeof(Presentation.Controllers.EmergencyController).Assembly);


            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(AllowedOrigin);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
