using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Extensions.DependencyInjection;
using MauiAppSample.ViewModels;
using MauiAppSample.Services.Interfaces;
using MauiAppSample.Services;

[assembly: XamlCompilationAttribute(XamlCompilationOptions.Compile)]

namespace MauiAppSample
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.UseMauiApp<App>()
				.ConfigureServices((services) =>
				{
					services.AddScoped<INavigationService, NavigationService>();
					services.AddScoped<HomeViewModel>();
					services.AddScoped<CoursesListViewModel>();
					services.AddScoped<FlyoutMenuViewModel>();
					services.AddScoped<MainPageViewModel>();
					services.AddScoped<RegisterViewModel>();
				})
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});
		}
	}
}