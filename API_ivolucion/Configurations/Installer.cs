using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace API_ivolucion.Configurations
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }

    public static class InstallerExtension
    {
        public static void InstallServicesAssembly(IServiceCollection services, IConfiguration configuration)
        {

            var Services = typeof(Startup).Assembly.ExportedTypes.Where(type =>
                typeof(IInstaller).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            Services.ForEach(installer => installer.InstallServices(services, configuration));

        }
    }
}
