﻿using GameTv.Models;
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
    public partial class NewsAoeView : ContentPage
    {
        public NewsAoeView()
        {
            InitializeComponent();
        }

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var model = BindingContext as NewsAoeViewModel;
            if(e.ItemIndex==model.AoeNews.Count - 2)
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