using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaKeyPad.Models;
using AvaloniaKeyPad.ViewModels;
using AvaloniaKeyPad.ViewModels.Actions;
using AvaloniaKeyPad.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaKeyPad
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var services = new ServiceCollection()
                .AddSingleton<IDataRepository, DataRepository>()
                .AddSingleton<IMenuViewModel, MenuViewModel>()
                .AddSingleton<IButtonViewModelFactory, ButtonViewModelFactory>()
                .AddSingleton<IActionViewModelFactory, ActionViewModelFactory>()
                .AddScoped<IStatusBarViewModel, StatusBarViewModel>()
                .AddSingleton<MainWindowViewModel>();

            var serviceProvider = services.BuildServiceProvider();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = serviceProvider.GetService<MainWindowViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
