using GameTv.Services.Navigation;
using GameTv.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameTv.Views.Aoe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeAoeView : TabbedPage
    {
        public HomeAoeView()
        {
            InitializeComponent();
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            if(CurrentPage != null)
            {
                SetViewModelByView(CurrentPage);
            }
        }
        public void SetViewModelByView(Xamarin.Forms.Page view)
        {
            if (view.BindingContext != this.BindingContext && view.BindingContext is ViewModelBase vm)
            {
                vm.OnNavigationAsync(new NavigationParameters(), NavigationType.Back);
                return;
            }
            var viewType = view.GetType();
            var viewModelType = Type.GetType(viewType.FullName.Replace("View", "ViewModel"));
            if (viewModelType == null)
                throw new Exception($"Mapping type of {viewModelType} is not a Page");
            vm = ServiceLocator.Instance.Resolve(viewModelType) as ViewModelBase;
            if (vm != null)
            {
                view.BindingContext = vm;
                vm.OnNavigationAsync(new NavigationParameters(),NavigationType.New);
            }
        }
    }
}