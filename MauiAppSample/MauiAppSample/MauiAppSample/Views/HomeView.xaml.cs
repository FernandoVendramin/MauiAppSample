using MauiAppSample.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiApp1.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}