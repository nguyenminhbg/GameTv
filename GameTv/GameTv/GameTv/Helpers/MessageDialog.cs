using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTv.Helpers
{
    public class MessageDialog
    {
        public static void ToastErrorLoadData()
        {
            UserDialogs.Instance.HideLoading();
            UserDialogs.Instance.Toast("Xảy ra lỗi kết nối với dữ liêu");
        }

        public static void ToastErrorLoad()
        {
            UserDialogs.Instance.Toast("Xảy ra lỗi kết nối với dữ liêu");
        }
        public static void ToastDeleteNews()
        {
            UserDialogs.Instance.Toast("Đã xóa tin tức khỏi mục yêu thích");
        }
        public static void ToastInsertNews()
        {
            UserDialogs.Instance.Toast("Đã thêm tin tức vào mục yêu thích");
        }
        public static void ToastDeleteVideo()
        {
            UserDialogs.Instance.Toast("Đã xóa video khỏi mục yêu thích");
        }
        public static void ToastInsertVideo()
        {
            UserDialogs.Instance.Toast("Đã thêm video vào mục yêu thích");
        }
        public static void ToastEmptyData()
        {
            UserDialogs.Instance.HideLoading();
            UserDialogs.Instance.Toast("Không có dữ liệu");
        }

        public static void LoadingData()
        {
            UserDialogs.Instance.ShowLoading("Loading");
        }

        public static void HideLoadingDate()
        {
            UserDialogs.Instance.HideLoading();
        }

        public static string ReturnHtml()
        {
            return
                "<html><head><style>img{max-width: 70%; width:auto; height: auto;}h1{color:blue;font-size: 150%}</style></head><body><div>Xảy ra lỗi tải trang</div></body></html>";
        }

        public static void ToastErrorConnect()
        {
            UserDialogs.Instance.Toast("Xảy ra lỗi kết nối mạng");
            UserDialogs.Instance.HideLoading();
        }

        public static void ToastUpdateCapNhat()
        {
            UserDialogs.Instance.Toast("Cập nhật dữ liệu");
        }
    }
}
