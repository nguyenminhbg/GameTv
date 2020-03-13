using GameTv.Helpers;
using GameTv.Models;
using GameTv.ViewModels.Base;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GameTv.ViewModels.Aoe
{
  public  class NewsAoeScoreViewModel: ViewModelBase
    {
        private ObservableCollection<ScoreSheet> aoeScore;
        public ObservableCollection<ScoreSheet> AoeScore
        {
            get => aoeScore;
            set { SetProperty(ref aoeScore, value); }
        }
        public NewsAoeScoreViewModel()
        {
            GetNewsList();
        }
        public async void GetNewsList()
        {
            try
            {
                var html = "https://vectv.net/";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument(); 
                var htmlDoc = await web.LoadFromWebAsync(html);
                var nodeTabDesk = htmlDoc.DocumentNode.Descendants("div").Where(t => t.GetAttributeValue("class", "") == "site-content site-content-desktopxxx").ToList(); 
                var nodeTab = nodeTabDesk.ToArray()[0].Descendants("div").Where(t => t.GetAttributeValue("class", "") == "container").ToList();
                var sildeBar = nodeTab.LastOrDefault().Descendants("div").Where(t => t.GetAttributeValue("id", "") == "sidebar");
                var nodeTab1 = sildeBar.ToArray()[0].Descendants("aside").Where(t => t.GetAttributeValue("class", "") == "widget card widget--sidebar widget-game-result").ToList();
                var team1 = nodeTab1.LastOrDefault().Descendants("div").Where(t => t.GetAttributeValue("class", "") == "widget-game-result__team widget-game-result__team--first");
                var team1div = team1.ToArray()[0].Descendants("div").Where(t => t.GetAttributeValue("class", "") == "widget-game-result__team-info");
                var name1 = team1.ToArray()[0].Descendants("h5").ToArray()[0].InnerText; 
                var team2 = nodeTab1.ToArray()[0].Descendants("div").Where(t => t.GetAttributeValue("class", "") == "widget-game-result__team widget-game-result__team--second");
                IsLoading = false;
                IsRefreshing = false;
            }
            catch (Exception ex)
            {
                IsRefresh = true;
                IndexPageNews--;
                MessageDialog.ToastErrorLoad();
            }
        }
    }
}
