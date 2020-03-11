using GameTv.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTv.Services.Navigation
{
    public enum NavigationType
    {
        New,
        Back,
    }
    public interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateToAsync<T>() where T:ViewModelBase;
        Task NavigateToAsync<TViewModel>(NavigationParameters parameters) where TViewModel : ViewModelBase;

        Task NavigateToAsync(Type viewModelType);

        Task NavigateToAsync(Type viewModelType, NavigationParameters parameters);

        Task NavigateBackAsync();

        Task NavigateBackAsync(NavigationParameters parameters);

        Task NavigateBackToMainPageAsync();
    }
}
