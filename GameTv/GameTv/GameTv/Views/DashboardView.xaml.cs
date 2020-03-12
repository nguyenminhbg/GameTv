using GameTv.Controls;
using GameTv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameTv.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardView : MasterDetailPage
    {
        public List<Game> MenuList { get; set; }
        public DashboardView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            App.InitialGame();
            MenuList = App.List;
            MenuGame.ItemsSource = MenuList;
            if(MenuList != null)
            {
                Type type= MenuList[0].TargetType;
                Detail = new CustomNavigationBase((Page)Activator.CreateInstance(type));
            }
        }

        private async void MenuGame_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var list = (ListView)sender;
            Game item = (Game)list.SelectedItem;
            Page detail = Detail.Navigation.NavigationStack.Last();
            Type page = item.TargetType;
            list.SelectedItem = null;
            if (!detail.Title.Equals(item.Name))
            {
                Page displayPage = (Page)Activator.CreateInstance(page);
                Detail.Navigation.InsertPageBefore(displayPage, detail);
                await Detail.Navigation.PopAsync();
            }
            IsPresented = false;
        }
    }
}