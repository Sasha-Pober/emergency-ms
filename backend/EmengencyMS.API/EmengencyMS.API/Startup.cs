using Microsoft.Extensions.Configuration;

namespace EmengencyMS.API
{
    public class Startup
    {
        readonly string AllowedOrigin = "allowedOrigin";

        private readonly IConfiguration _сonfiguration;

        public Startup(IWebHostEnvironment environment)
        {
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

            services.AddControllers().AddApplicationPart(typeof(Presentation.Controllers.EmergencyController).Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(AllowedOrigin);
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
