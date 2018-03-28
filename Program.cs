using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using TraccarApi.Business;
using TraccarApi.Business.Entities;

namespace TraccarApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                         .AddUserSecrets<Startup>()
                         .AddEnvironmentVariables();

                   Log.Logger = new LoggerConfiguration()
                                   .MinimumLevel.Debug()
                                   .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                                   .MinimumLevel.Override("System", LogEventLevel.Warning)
                                   .Enrich.FromLogContext()
                                   .Enrich.WithMachineName()
                                   .Enrich.WithThreadId()
                                   .WriteTo.ColoredConsole()
                                   .WriteTo.RollingFile(Path.Combine(hostingContext.HostingEnvironment.ContentRootPath, "Logs/{Date}.txt"))
                                   .CreateLogger();
               })
               .ConfigureLogging((hostingContext, logging) =>
               {
                   logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                   logging.AddDebug();
                   logging.AddSerilog();
                    //logging.AddConsole();
                })
               .UseStartup<Startup>()
               .Build();

            webHost.Run();
        }
    }
}
