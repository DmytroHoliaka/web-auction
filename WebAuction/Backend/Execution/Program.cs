namespace WebAuction.Backend.Execution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            Configurator.ConfigureApplication(builder);

            WebApplication app = builder.Build();
            Configurator.ConfigureMiddlewares(app);

            app.Run();
        }
    }
}