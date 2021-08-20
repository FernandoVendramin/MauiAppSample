using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MauiApp1.Views;
using MauiAppSample.Models;
using MauiAppSample.ViewModels.Base;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiAppSample.ViewModels
{
    public class FlyoutMenuViewModel : ViewModelBase
    {
        private readonly INavigation _navigation;

        public FlyoutMenuViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoadData();
            NavigateCommand = new Command<Type>(async (Type type) => await NavigateAsync(type));
        }

        public ICommand NavigateCommand { get; set; }

        private ObservableCollection<FlyoutPageItem> pages = new ObservableCollection<FlyoutPageItem>();
        public ObservableCollection<FlyoutPageItem> Pages
        {
            get
            {
                return pages;
            }
            set
            {
                pages = value;
                OnPropertyChanged(nameof(Pages));
            }
        }

        private void LoadData()
        {
            var pages = new List<FlyoutPageItem>()
            {
                new ("Menu", "home.png", typeof(HomeView))
            };

            Pages = new ObservableCollection<FlyoutPageItem>(pages);
        }

        private async Task NavigateAsync(Type type)
        {
            if (nameof(type) == nameof(HomeView))
            {
                await _navigation.PushAsync(new HomeView());
            }

            //if (nameof(type) == nameof())
            //{
            //    await _navigation.PushAsync(new HomeView());
            //}
        }
    }
}
