using MathLoopProblem;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;



CreateLogger();

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<IMathHelper, MathHelper>();
        services.AddSingleton((x) => Log.Logger);
    })
    .UseSerilog()
    .Build();

Log.Information("Application Starting ...");

var srv = ActivatorUtilities.CreateInstance<MathHelper>(host.Services);
srv.Start();







static void CreateLogger()
{
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


    Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
}
