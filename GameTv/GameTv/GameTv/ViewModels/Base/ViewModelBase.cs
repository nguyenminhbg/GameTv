using GameTv.Mvvm;
using GameTv.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTv.ViewModels.Base
{
    public class ViewModelBase:BindableBase
    {
        INavigationService NavigationService { get; }
        public ViewModelBase()
        {
            NavigationService = ServiceLocator.Instance.Resolve<INavigationService>();
        }
        public virtual Task OnNavigationAsync(NavigationParameters parameter, NavigationType type)
        {
            return Task.CompletedTask;
        }
    }
}
