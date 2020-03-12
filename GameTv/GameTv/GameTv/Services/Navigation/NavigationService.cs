using GameTv.Controls;
using GameTv.ViewModels;
using GameTv.ViewModels.Base;
using GameTv.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameTv.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        protected Application CurrentApplication => Application.Current;
        protected Page FindViewByViewModel(Type viewModelType)
        {
            try
            {
                var viewType = Type.GetType(viewModelType.FullName.Replace("ViewModel", "View"));
                if (viewType != null)
                {
                    var view = Activator.CreateInstance(viewType) as Page;
                    view.BindingContext = ServiceLocator.Instance.Resolve(viewModelType);
                    return view;
                }
                else throw new Exception($"Name of mapping not correct, name is {viewModelType}");
            }
            catch (Exception ex)
            {
                Debugger.Break();
                throw;
            }
        }
        public Task InitializeAsync()
        {
            return NavigateToAsync<DashboardViewModel>();
        }

        public Task NavigateBackAsync()
        {
            return NavigateBackAsync(null);
        }

        public async Task NavigateBackAsync(NavigationParameters parameters)
        {
            if (CurrentApplication.MainPage is CustomNavigationBase navigationBase)
            {
                await navigationBase.PopAsync();
               if (navigationBase.Navigation.NavigationStack.LastOrDefault() is Page view)
                {
                    if(view.BindingContext is ViewModelBase vm)
                    {
                       await vm.OnNavigationAsync(parameters, NavigationType.Back);
                    }
                }
            }
        }

        public async Task NavigateBackToMainPageAsync()
        {
            if (!(CurrentApplication.MainPage is CustomNavigationBase))
                return;

            for (var i = CurrentApplication.MainPage.Navigation.NavigationStack.Count - 2; i > 0; i--)
                CurrentApplication.MainPage?.Navigation.RemovePage(CurrentApplication.MainPage.Navigation
                    .NavigationStack[i]);

            await CurrentApplication.MainPage.Navigation.PopAsync();
        }

        public Task NavigateToAsync<T>() where T : ViewModelBase
        {
            return NavigateToAsync(typeof(T), new NavigationParameters());
        }

        public Task NavigateToAsync<TViewModel>(NavigationParameters parameters) where TViewModel : ViewModelBase
        {
            return NavigateToAsync(typeof(TViewModel), new NavigationParameters());
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return NavigateToAsync(viewModelType, new NavigationParameters());
        }

        public async Task NavigateToAsync(Type viewModelType, NavigationParameters parameters)
        {
            var view = FindViewByViewModel(viewModelType);
            if (view is DashboardView)
            {
                CurrentApplication.MainPage = new CustomNavigationBase(view);
            }
            else if (CurrentApplication.MainPage is CustomNavigationBase customNavigation)
            {
                await customNavigation.PushAsync(view);
            }
            else
            {
                CurrentApplication.MainPage = new CustomNavigationBase(view);
            }
            if (view.BindingContext is ViewModelBase vm)
            {
                await vm.OnNavigationAsync(parameters, NavigationType.New);
            }
        }
    }
}
