using MauiAppSample.Services.Interfaces;
using MauiAppSample.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public RegisterViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
