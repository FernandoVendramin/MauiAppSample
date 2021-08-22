using MauiAppSample.Services.Interfaces;
using System.ComponentModel;

namespace MauiAppSample.ViewModels.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly INavigationService NavigationService;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
