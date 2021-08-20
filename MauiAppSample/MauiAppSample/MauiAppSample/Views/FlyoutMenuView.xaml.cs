using MauiAppSample.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiApp1.Views
{
    public partial class FlyoutMenuView : ContentPage
    {
        public FlyoutMenuView()
        {
            InitializeComponent();
            BindingContext = new FlyoutMenuViewModel(Navigation);
        }
    }
}