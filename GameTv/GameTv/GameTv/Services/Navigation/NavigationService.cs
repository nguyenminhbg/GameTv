using GameTv.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTv.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateBackAsync(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task NavigateBackToMainPageAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<T>() where T : ViewModelBase
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>(NavigationParameters parameters) where TViewModel : ViewModelBase
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(Type viewModelType, NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
