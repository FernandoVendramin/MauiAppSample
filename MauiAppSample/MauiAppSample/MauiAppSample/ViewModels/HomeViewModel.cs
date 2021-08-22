using MauiAppSample.Services.Interfaces;
using MauiAppSample.ViewModels.Base;

namespace MauiAppSample.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }
    }
}
