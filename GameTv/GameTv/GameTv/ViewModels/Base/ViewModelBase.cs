using GameTv.Models;
using GameTv.Mvvm;
using GameTv.Mvvm.Commands;
using GameTv.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameTv.ViewModels.Base
{
    public class ViewModelBase:BindableBase
    {
      public  INavigationService NavigationService { get; }
        public ViewModelBase()
        {
            NavigationService = ServiceLocator.Instance.Resolve<INavigationService>();
            SelectedNew = new DelegateCommand<News>(SelectedExecute);
            RefreshCommand = new DelegateCommand(RefreshExecute);
            IsLoading = true;
            IsRefresh = false;
            IndexPageNews = 1;
            IsMore = false;
        }
        private bool _isMore;

        public bool IsMore
        {
            get { return _isMore; }
            set { SetProperty(ref _isMore, value); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public virtual void RefreshExecute()
        {
            if (IsRefreshing) return;
            IsRefreshing = true;
            IndexPageNews = 1;
        }
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }
        public ICommand RefreshCommand { get; set; }
        public virtual void SelectedExecute(News news)
        {
            throw new NotImplementedException();
        }


        public virtual Task OnNavigationAsync(NavigationParameters parameter, NavigationType type)
        {
            return Task.CompletedTask;
        }
        private bool isRefresh;
        public bool IsRefresh
        {
            get { return isRefresh; }
            set { SetProperty(ref isRefresh, value); }
        }
        public int IndexPageNews;
        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref isLoading, value); }
        }
        private ICommand SelectedNew;
        private News _selectedItem;
        public News SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (_selectedItem == null)
                {
                    return;
                }
                SelectedNew.Execute(_selectedItem);
                _selectedItem = null;

            }
        }
    }
}
