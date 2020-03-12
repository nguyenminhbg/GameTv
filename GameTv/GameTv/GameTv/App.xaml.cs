using GameTv.Models;
using GameTv.Services.Navigation;
using GameTv.ViewModels;
using GameTv.Views;
using GameTv.Views.Aoe;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameTv
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            BuildDependencies();
            InitNavigation();
        }
        public static List<Game> List;
        static List<Game> Items = new List<Game>
        {
            new Game() { Name = "AOE", Image = "logo_gametv.png", Iswitch = false, TargetType =typeof(HomeAoeView) },
            new Game { Name = "Liên Quân Mobile", Image = "lienquan.png", Iswitch = false, TargetType = typeof(TempView) },
            new Game() { Name = "Liên Minh Huyền Thoại", Image = "lol.png", Iswitch = false, TargetType = typeof(TempView) },
            new Game() { Name = "PES", Image = "pestvtrang.png", Iswitch = false, TargetType = typeof(TempView) },
            new Game() { Name = "Yêu thích", Image = "Ic_BookMark.png", Iswitch = false, TargetType = typeof(TempView) },
            new Game() { Name = "Cài đặt", Image = "setting.png", Iswitch = false, TargetType = typeof(TempView) }

        };
        public static void InitialGame()
        {
            List = new List<Game>();
            if (List.Count == 0)
            {
                List = Items;
            }

        }
        public void BuildDependencies()
        {
            if (ServiceLocator.Instance.Built) return;
   
            ServiceLocator.Instance.RegisterInstance<INavigationService,NavigationService>();
            ServiceLocator.Instance.RegisterViewModels();
            ServiceLocator.Instance.Build();// Build Container
        }
        public void InitNavigation()
        {
            ServiceLocator.Instance.Resolve<INavigationService>().NavigateToAsync<DashboardViewModel>();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
