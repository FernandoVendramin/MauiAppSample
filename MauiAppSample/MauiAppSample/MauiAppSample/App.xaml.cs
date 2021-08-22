using MauiAppSample.Services.Interfaces;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace MauiAppSample
{
	public partial class App : Application
	{
		public App(INavigationService navigationService)
		{
			InitializeComponent();
			navigationService.Initialize();
		}
	}
}
