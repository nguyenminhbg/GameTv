using GameTv.Helpers;
using GameTv.Services.Navigation;
using GameTv.ViewModels.Base;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameTv.ViewModels.Aoe
{
    public class DetailNewsViewModel : ViewModelBase
    {
        private string _detailNews;
        public string DetailNews
        {
            get { return _detailNews; }
            set { SetProperty(ref _detailNews, value); }
        }
        public DetailNewsViewModel()
        {

        }
        private string _uri;
        public override Task OnNavigationAsync(NavigationParameters parameter, NavigationType type)
        {
            if (parameter.ContainsKey("Url"))
            {
                _uri = parameter["Url"].ToString();
                if (_uri != null)
                {
                    GetDetailNews(_uri);

                }

            }
            if (parameter.ContainsKey("Title"))
            {
                Title = parameter["Title"].ToString();
            }
            return base.OnNavigationAsync(parameter, type);
        }
        private string url;
        public string Url
        {
            get => url;
            set { SetProperty(ref url, value); }
        }
        public async void GetDetailNews(string uri)
        {
            try
            {
                IsMore = true;
                HtmlWeb web = new HtmlWeb();
                HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                var htmlDoc = await web.LoadFromWebAsync(uri);
                var nodeRoot = htmlDoc.DocumentNode.Descendants("div").Where(t => t.GetAttributeValue("class", "") == "wrapper container");
                var node1 = nodeRoot.LastOrDefault().Descendants("section").Where(t => t.GetAttributeValue("class", "") == "main_wrapper");
                var node2 = node1.LastOrDefault().Descendants("div").Where(t => t.GetAttributeValue("class", "") == "row");
                var node3 = node2.LastOrDefault().Descendants("div").Where(t => t.GetAttributeValue("class", "") == "news-main");
                var node4 = node3.LastOrDefault().Descendants("div").Where(t => t.GetAttributeValue("class", "") == "single-news-title");
                Title = node4.LastOrDefault().Descendants("h1").LastOrDefault().InnerText;
                var node5 = node3.LastOrDefault().Descendants("div").Where(t => t.GetAttributeValue("class", "") == "single-news-info");
                var subContent = node5.LastOrDefault().Descendants("h2").LastOrDefault().InnerText;
                var node6 = node3.LastOrDefault().Descendants("div").Where(t => t.GetAttributeValue("class", "") == "single-news-content").ToArray()[0];
                var content = node6.InnerHtml;
                string html =
                    "<!DOCTYPE html>" +
                        "<html>" +
                       "<head>" +
                       "<style>img{max-width: 100%; width:auto; max-height: 250;}h1{color:blue;font-size: 100%}</style> " +
                          "</head>" +
                          "<body>" +
                           "<p  style =\"font-family:georgia,garamond,serif; font-size:22px; font-style:bold;font-weight:bold;\">" + Title + "</p>" +
                           "<p style =\"font-family:georgia,garamond,serif; font-size:18px; font-style:bold;font-weight:bold;\">" + subContent+"</p>"+
                                   content +
                       "<h1>Nguồn gametv.vn<h1></body>" +
                       "</html>";
                Device.BeginInvokeOnMainThread(() =>
                {
                    DetailNews = html;
                    IsMore = false;
                });
            }
            catch (Exception e)
            {
                IsMore = false;
                MessageDialog.ToastErrorLoad();
                DetailNews = MessageDialog.ReturnHtml();
                MessageDialog.ReturnHtml();
            }
        }
    }
}
