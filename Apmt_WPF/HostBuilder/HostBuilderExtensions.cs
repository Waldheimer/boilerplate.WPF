using Apmt_WPF.Features.Appointments;
using Apmt_WPF.Features.Dashboard;
using Apmt_WPF.Features.MainWindow;
using Apmt_WPF.Features.Users;
using Apmt_WPF.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scrutor;
using System.CodeDom;
using System.Reflection;
using System.Windows;

namespace Apmt_WPF.HostBuilder;

public static class HostBuilderExtensions
{
    //  *****************************************************************************
    //  *****   Registration of all ViewModels for DI   *****************************
    //  *****************************************************************************
    public static IHostBuilder RegisterViewModels(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<DashboardViewModel>();
            services.AddSingleton<AppointmentsViewModel>();
        });
        return hostBuilder;
    }
    //  *****************************************************************************
    //  *****   Registration of all Views/Components for DI   ***********************
    //  *****************************************************************************
    public static IHostBuilder RegisterViews(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            //services.AddSingleton<MainWindow>();
            services.AddSingleton<DashboardView>();
            services.AddSingleton<AppointmentsView>();
        });
        return hostBuilder;
    }
    //  *****************************************************************************
    //  *****   Registration of all ManagerClasses for DI   *************************
    //  *****************************************************************************
    public static IHostBuilder RegisterManagers(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddScoped<NavigationManager>();
        });
        return hostBuilder;
    }
    //  *****************************************************************************
    //  *****   Registration of all ContextClasses for DI   *************************
    //  *****************************************************************************
    public static IHostBuilder RegisterContexts(this IHostBuilder hostBuilder)
    {
        
        return hostBuilder;
    }
    //  *****************************************************************************
    //  *****   Registration of all ServiceClasses for DI   *************************
    //  *****************************************************************************
    public static IHostBuilder RegisterServices(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<NavigationService<DashboardViewModel>>();
            services.AddSingleton<NavigationService<AppointmentsViewModel>>();
            services.AddSingleton<UserService>();
        });
        return hostBuilder;
    }
    //  *****************************************************************************
    //  *****   Registration of Factory Functions for DI   **************************
    //  ***** Generic Factory-Functions for Navigation  *****************************
    //  *****************************************************************************
    public static IHostBuilder RegisterFactoryFunctions(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<Func<DashboardViewModel>>(s => () => s.GetRequiredService<DashboardViewModel>());
            services.AddSingleton<Func<AppointmentsViewModel>>(s => () => s.GetRequiredService<AppointmentsViewModel>());
        });
        return hostBuilder;
    }
}
