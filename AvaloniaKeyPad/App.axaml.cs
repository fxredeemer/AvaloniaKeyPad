using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaKeyPad.ViewModels;
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
                 .AddSingleton<IMenuViewModel, MenuViewModel>()
                 .AddScoped<IButtonViewModel, ButtonViewModel>()
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