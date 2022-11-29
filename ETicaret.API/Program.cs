using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Events;

namespace ETicaret.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
      .WriteTo.Console()
      .WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
      .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
      .WriteTo.Seq("http://localhost:5341/")
      .MinimumLevel.Information()
      .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
      //.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
      //.Enrich.WithProperty("AppName", "E-Ticaret Serilog")
      //.Enrich.WithProperty("Environment", "Development")
      //.Enrich.WithProperty("Coder", "Can")
      .CreateLogger();
            Log.Verbose("Verbose");
            Log.Debug("Debug");
            Log.Information("Information");
            Log.Warning("Warning");
            Log.Error("Error");
            Log.Fatal("Fatal");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.UseStartup<Startup>();
           })
       .ConfigureLogging(config => config.ClearProviders())
       .UseSerilog();
    }
}
