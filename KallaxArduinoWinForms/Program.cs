using KallaxArduinoDataAccess;
using KallaxArduinoDataAccess.ArduinoDataAccess;
using KallaxArduinoDataAccess.PackageDataAccess;
using KallaxArduinoDataAccess.StationDataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KallaxArduinoWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        { 

             IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<PackstionForm>()
            .Build();


            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder(configuration).Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<PackstionForm>());

        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder(IConfiguration configuration)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    string connectionString = configuration.GetConnectionString("Default");
                    services.AddSingleton(configuration);
                    services.AddSingleton<IArduinoAccess, ArduinoAccess>();
                    services.AddSingleton<ISQLDataAccess, SQLDataAccess>();
                    services.AddSingleton<IStationAccess, StationAccess>();
                    services.AddSingleton<IPackageAccess, PackageAccess>();
                    services.AddSingleton<IContainerAccess, ContainerAccess>();
                    services.AddTransient<PackstionForm>();
                });
        }
    }

}