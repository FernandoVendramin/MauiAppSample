using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MauiApp1.Views;
using MauiAppSample.Models;
using MauiAppSample.ViewModels.Base;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiAppSample.Services.Interfaces;

namespace MauiAppSample.ViewModels
{
    public class FlyoutMenuViewModel : ViewModelBase
    {
        public FlyoutMenuViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigateCommand = new Command<Type>(async (Type type) => await NavigateAsync(type));
        }

        public ICommand NavigateCommand { get; set; }

        private async Task NavigateAsync(Type type)
        {
            if (type == typeof(HomeView))
            {
                await NavigationService.NavigateToAsync<HomeViewModel>();
            }

            if (type == typeof(CoursesListView))
            {
                await NavigationService.NavigateToAsync<CoursesListViewModel>();
            }

            if (type == typeof(RegisterView))
            {
                await NavigationService.NavigateToAsync<RegisterViewModel>();
            }
        }
    }
}
