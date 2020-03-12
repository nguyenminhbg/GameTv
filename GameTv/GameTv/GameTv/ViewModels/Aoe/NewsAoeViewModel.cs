using GameTv.Models;
using GameTv.ViewModels.Base;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameTv.ViewModels.Aoe
{
    public class NewsAoeViewModel : ViewModelBase
    {
        private ObservableCollection<News> aoeNews;
        public ObservableCollection<News> AoeNews
        {
            get => aoeNews; set { SetProperty(ref aoeNews, value); }
        }
        public NewsAoeViewModel()
        {
            AoeNews = new ObservableCollection<News>();
            GetData();
        }
        public void GetData()
        {
            GetNewsList(1);
        }
        public async void GetNewsList(int indexPage)
        {
            try
            {
                var html = "https://www.gametv.vn/aoe?page=1";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                var htmlDoc =await web.LoadFromWebAsync(html);
                var nodeTab = htmlDoc.DocumentNode.Descendants("div").Where(t => t.GetAttributeValue("class", "") == "wrapper container");
                var nodeTab1 = nodeTab.LastOrDefault().Descendants("section").Where(t => t.GetAttributeValue("class", "") == "main_wrapper");
                var nodeTab2 = nodeTab.LastOrDefault().Descendants("div").Where(t => t.GetAttributeValue("class", "") == "row first-row");
                var nodeTab3= nodeTab.LastOrDefault().Descendants("div").Where(t => t.GetAttributeValue("class", "")== "col-md-8 row-col").ToList();

                foreach (var item in nodeTab2)
                        {
                           GetNewsList(item);
                       }
                //using (var client = new HttpClient())
                //{
                //    client.Timeout = TimeSpan.FromMilliseconds(5000);
                //    using (var stream =
                //       await client.GetStreamAsync("https://gametv.vn/news?paged=" + indexPage))
                //    {

                    //        var htmlDoc = new HtmlAgilityPack.HtmlDocument();

                    //        Device.BeginInvokeOnMainThread(async () =>
                    //        {
                    //            htmlDoc.Load(stream);
                    //        });
                    //        var items = htmlDoc.DocumentNode.Descendants("li")
                    //                .Where(e => e.GetAttributeValue("class", "") == "news__item post");
                    //        foreach (var item in items)
                    //        {
                    //            AoeNews.Add(GetNewsList(item));
                    //        }
                    //    }
                    //}


            }
            catch (Exception ex)
            {

            }
        }

        public void GetNewsList(HtmlNode htmlNode)
        {
            
            // Lấy tất cả các thẻ div có class: row latest-news-col
            var nodeDiv = htmlNode.ChildNodes.Descendants("div").Where(t => t.GetAttributeValue("class", "") == "row latest-news-col");
            for(int i = 0; i < nodeDiv.Count(); ++i)
            {
                News myNews = new News();
                var nodeDiv1 = htmlNode.ChildNodes.Descendants("div").Where(t => t.GetAttributeValue("class", "") == "col-md-5 row-col late-news-img");
                var nodeDiv2 = htmlNode.ChildNodes.Descendants("div").Where(t => t.GetAttributeValue("class", "") == "col-md-7 row-col late-news-text");
                var uri = nodeDiv1.ToArray()[i].Descendants("a").FirstOrDefault()?.GetAttributeValue("href", "");
                if (!uri.Contains("https:"))
                {
                    uri = "https:" + uri;
                }
                myNews.Uri = new Uri(uri);
                myNews.Image = new Uri(nodeDiv1.ToArray()[i].Descendants("img").FirstOrDefault()
                       ?.GetAttributeValue("src", ""));
                var a = nodeDiv1.ToArray()[i].Descendants("a").FirstOrDefault()?.GetAttributeValue("title", "Không lấy được Title");
                var p = nodeDiv2.ToArray()[i].Descendants("p").Where(t => t.GetAttributeValue("class", "") == "news-summary").LastOrDefault().InnerText;
                var time = nodeDiv2.ToArray()[i].Descendants("p").Where(t => t.GetAttributeValue("class", "") == "news-info").LastOrDefault().InnerText;
                myNews.Title = a;
                myNews.Content = p;
                myNews.TimePost = time;
               AoeNews.Add(myNews);
            }
        }
    }
}
