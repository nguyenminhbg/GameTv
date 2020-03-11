using System;
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
        }
        public void BuildDependencies()
        {
            ServiceLocator.Instance.Build();// Build Container
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
