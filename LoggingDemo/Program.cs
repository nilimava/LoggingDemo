
namespace LoggingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            ////configure Logging providers
            //builder.Logging.ClearProviders();
            //builder.Logging.AddConsole();
            //builder.Logging.AddDebug();

            ////set specific log levels for different libraries

            //builder.Logging.SetMinimumLevel(LogLevel.Information);
            //builder.Logging.AddFilter("Microsoft", LogLevel.Warning);
            //builder.Logging.AddFilter("Microsoft.AspNetCore", LogLevel.Warning);
            //builder.Logging.AddFilter("System", LogLevel.Warning);
            //builder.Logging.AddFilter("LoggingDemo.Controllers", LogLevel.Trace);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
           
           

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
