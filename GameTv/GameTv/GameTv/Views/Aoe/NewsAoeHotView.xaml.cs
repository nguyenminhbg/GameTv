using GameTv.ViewModels.Aoe;
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
    public partial class NewsAoeHotView : ContentPage
    {
        public NewsAoeHotView()
        {
            InitializeComponent();
        }
        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var model = BindingContext as NewsAoeHotViewModel;
            if (e.ItemIndex == model.AoeHotNews.Count - 2)
            {
                ++model.IndexPageNews;
                model.GetNewsList(model.IndexPageNews);
            }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var list = sender as ListView;
            if (list != null) list.SelectedItem = null;
        }
    }
}