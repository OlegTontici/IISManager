﻿using IISManager.Commands;
using Microsoft.Web.Administration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace IISManager.ViewModels
{
    public class SiteManagerViewModel : INotifyPropertyChanged
    {
        private ICommand onFullRecycleButtonClickedEventHandler;
        private ICommand onSiteStartButtonClickedEventHandler;
        private ICommand onSiteStopButtonClickedEventHandler;
        private ICommand onSiteRestartButtonClickedEventHandler;

        private string status;
        private ServerManager _serverManager;
        private Site _site;

        public IEnumerable<string> Bindings { get; set; }
        public IEnumerable<ApplicationManagerViewModel> SiteApplications { get; set; }
        public int SelectedApplicationIndex { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Status
        {
            get
            {
                return _site.State.ToString(); 
            }
            set
            {
                status = value;
                NotifyPropertyChanged(nameof(Status));
            }
        }        
        public string SiteName
        {
            get { return _site.Name; }
        }
        public ICommand OnFullRecycleButtonClickedEventHandler
        {
            get
            {
                return onFullRecycleButtonClickedEventHandler ?? (onFullRecycleButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    _site.Stop();

                    foreach (var a in _site.Applications)
                    {
                        _serverManager.ApplicationPools.Single(appPool => appPool.Name == a.ApplicationPoolName).Recycle();
                    }

                    _site.Start();
                }));
            }
        }
        public ICommand OnSiteStartButtonClickedEventHandler
        {
            get
            {
                return onSiteStartButtonClickedEventHandler ?? (onSiteStartButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    _site.Start();
                }));
            }
        }
        public ICommand OnSiteStopButtonClickedEventHandler
        {
            get
            {
                return onSiteStopButtonClickedEventHandler ?? (onSiteStopButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    _site.Stop();
                }));
            }
        }
        public ICommand OnSiteRestartButtonClickedEventHandler
        {
            get
            {
                return onSiteRestartButtonClickedEventHandler ?? (onSiteRestartButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    _site.Stop();
                    _site.Start();
                }));
            }
        }

        public SiteManagerViewModel(ServerManager serverManager, Site site)
        {
            _serverManager = serverManager;
            _site = site;
            SiteApplications = _site.Applications.Select(app => new ApplicationManagerViewModel(_serverManager, app));
            SelectedApplicationIndex = 0;
            Bindings = _site.Bindings.Select(b => $@"{b.Protocol}://{b.Host}");
        }        

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
