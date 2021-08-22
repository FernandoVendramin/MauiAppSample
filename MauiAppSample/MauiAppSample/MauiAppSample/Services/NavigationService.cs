using MauiApp1.Views;
using MauiAppSample.Services.Interfaces;
using MauiAppSample.ViewModels;
using MauiAppSample.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Services
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;
        private readonly IServiceProvider _serviceProvider;

        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public NavigationService(IServiceProvider serviceProvider)
        {
            _mappings = new Dictionary<Type, Type>();
            _serviceProvider = serviceProvider;
            CreatePageViewModelMappings();
        }

        public void Initialize()
        {
            var mainPage = CreateAndBindPage(typeof(MainPageViewModel), null) as FlyoutPage;
            mainPage.Flyout = CreateAndBindPage(typeof(FlyoutMenuViewModel), null);
            mainPage.Detail = new NavigationPage(CreateAndBindPage(typeof(HomeViewModel), null));
            CurrentApplication.MainPage = mainPage;
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
            => InternalNavigateToAsync(typeof(TViewModel), null);

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
            => InternalNavigateToAsync(typeof(TViewModel), parameter);

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            var navigationPage = CurrentApplication.MainPage as NavigationPage;

            if (navigationPage != null)
            {
                await navigationPage.PushAsync(page);
            }
            else
            {
                var flyoutPage = CurrentApplication.MainPage as FlyoutPage;
                if (flyoutPage != null)
                {
                    flyoutPage.Detail = new NavigationPage(page);
                    flyoutPage.IsPresented = true;
                }
                else
                {
                    CurrentApplication.MainPage = new NavigationPage(page);
                }
            }
        }

        Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = _serviceProvider.GetService(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(HomeViewModel), typeof(HomeView));
            _mappings.Add(typeof(CoursesListViewModel), typeof(CoursesListView));
            _mappings.Add(typeof(RegisterViewModel), typeof(RegisterView));
            _mappings.Add(typeof(FlyoutMenuViewModel), typeof(FlyoutMenuView));
            _mappings.Add(typeof(MainPageViewModel), typeof(MainPage));
        }
    }
}