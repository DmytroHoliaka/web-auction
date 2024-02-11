using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebAuction.Backend.Database.Context;
using WebAuction.Backend.Database.Management;
using WebAuction.Backend.Middlewares;
using WebAuction.Backend.Validators;

namespace WebAuction.Backend.Execution
{
    public static class Configurator
    {
        public static void ConfigureApplication(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<DatabaseManager>();
            builder.Services.AddScoped<DatabaseValidator>();
            builder.Services.AddScoped<DataValidator>();
            builder.Services.AddScoped<FormValidator>();
        }

        public static void ConfigureMiddlewares(WebApplication app)
        {

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Frontend")),
                RequestPath = ""
            });

            app.UseMiddleware<CookieSetterMiddleware>();
            app.MapControllers();
        }
    }
}
