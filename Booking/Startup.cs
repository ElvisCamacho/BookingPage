using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Booking
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
            // **************** Adding Cors - Elvis  ************
            services.AddCors(options =>
            {
                // 1st policy --> allow specific Origin
                options.AddPolicy("AllowSpecificOrigin",
                    builder => { builder.WithOrigins("https://localhost:44342/api/booking").AllowAnyMethod().AllowAnyHeader(); });

                // 2st policy --> allow any Origins

                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin().
                        AllowAnyMethod().
                        AllowAnyHeader());

                // 3st policy --> allow specific Origins only Get & Post
                options.AddPolicy("AllowAnyOriginGetPost",
                    builder =>
                    {
                        builder.AllowAnyOrigin().WithMethods("GET", "PUT").AllowAnyHeader();
                    });


                options.AddPolicy("AccessControlAllowOrigin",
                    builder => builder.AllowAnyOrigin());
            });




            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking v1"));
            }
            app.UseCors("AllowAnyOrigin");

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
