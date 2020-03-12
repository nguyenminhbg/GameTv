using GameTv.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GameTv.Models
{
    public class News : BindableBase
    {
        private string _imgIsSave;

        public News()
        {
            Uri = new Uri("https://www.youtube.com/");
            Image = new Uri("https://www.youtube.com/");
            Name = "";
            TimePost = "";
            HourPost = "";
        }
        public Uri Uri { get; set; }

        public Uri Image { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string TimePost { get; set; }
        public string HourPost { get; set; }

        public string ImgIsSave
        {
            get { return _imgIsSave; }
            set { SetProperty(ref _imgIsSave, value); }
        }

        public byte[] ImageProperty { get; set; }

        public ImageSource MyImage { get; set; }
    }
}
