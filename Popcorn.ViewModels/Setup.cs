using Microsoft.Extensions.DependencyInjection;
using System;

namespace Popcorn.ViewModels
{
    public class Setup
    {
        public static IServiceProvider ConfigureServices()
        {
            var sc = new ServiceCollection();

            // Services
            sc.AddSingleton<Interfaces.ILoggerManager, Plugins.LoggerManager>();
            sc.AddSingleton<Interfaces.IJson, Plugins.JsonService>();
            sc.AddSingleton<Interfaces.IMovie, Services.MovieService>();

            // ViewModels
            sc.AddTransient<MainViewModel>();
            sc.AddTransient<DashboardViewModel>();
            sc.AddTransient<MovieDetailViewModel>();

            return sc.BuildServiceProvider();
        }
    }
}
