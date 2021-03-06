﻿using IISManager.Commands;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace IISManager.ViewModels
{
    public class ApplicationManagerViewModel 
    {
        private ICommand onAppPoolRecycleButtonClickedEventHandler;
        private ICommand onAppPoolStopButtonClickedEventHandler;
        private ICommand onAppPoolStartButtonClickedEventHandler;

        private ServerManager _serverManager;
        private Application _application;
        private ApplicationPool _applicationPool;
        private Notification _notification;


        public ApplicationInfo Info { get; set; }
        public ICommand OnAppPoolStartButtonClickedEventHandler
        {
            get
            {
                return onAppPoolStartButtonClickedEventHandler ?? (onAppPoolStartButtonClickedEventHandler = new CommandExecutor(() =>
                {                   
                    if (_applicationPool.State == ObjectState.Stopped)
                    {
                        ExecuteWithNotification(() =>
                        {
                            _applicationPool.Start();
                            Info.ApplicationPoolStatus = string.Empty;
                        });
                    }   
                }));
            }
        }
        public ICommand OnAppPoolStopButtonClickedEventHandler
        {
            get
            {
                return onAppPoolStopButtonClickedEventHandler ?? (onAppPoolStopButtonClickedEventHandler = new CommandExecutor(() =>
                {                    
                    if (_applicationPool.State == ObjectState.Started)
                    {
                        ExecuteWithNotification(() =>
                        {
                            _applicationPool.Stop();
                            Info.ApplicationPoolStatus = string.Empty;
                        });
                    }                    
                }));
            }
        }
        public ICommand OnAppPoolRecycleButtonClickedEventHandler
        {
            get
            {
                return onAppPoolRecycleButtonClickedEventHandler ?? (onAppPoolRecycleButtonClickedEventHandler = new CommandExecutor(() =>
                {
                    ExecuteWithNotification(() => _applicationPool.Recycle());                    
                }));
            }
        }

        public ApplicationManagerViewModel(
            ServerManager serverManager,
            Application application,
            Notification notification)
        {
            _serverManager = serverManager;
            _application = application;
            _applicationPool =
                _serverManager.
                ApplicationPools.
                SingleOrDefault(appPool => appPool.Name == _application.ApplicationPoolName);
            Info = new ApplicationInfo(_application, _applicationPool);
            _notification = notification;
        }



        private void ExecuteWithNotification(Action action)
        {
            try
            {
                action();
                _notification.ShowSuccess();
            }
            catch (Exception ex)
            {
                _notification.ShowError(ex.Message);
            }
        }
    }

    public class ApplicationInfo : INotifyPropertyChanged
    {
        private Application _application;
        private ApplicationPool _applicationPool;

        public event PropertyChangedEventHandler PropertyChanged;
        public string ApplicationName
        {
            get
            {
                return _application.Schema.Name;
            }
        }
        public string ApplicationPoolName
        {
            get
            {
                return _application.ApplicationPoolName;
            }
        }
        public string ApplicationPoolStatus
        {
            get
            {
                return _applicationPool.State.ToString();
            }
            set
            {
                NotifyPropertyChanged(nameof(ApplicationPoolStatus));
            }
        }
        public string EnabledProtocols
        {
            get
            {
                return _application.EnabledProtocols;
            }
        }
        public IEnumerable<string> VirtualDirectories
        {
            get
            {
                return _application.VirtualDirectories.Select(vd => vd.PhysicalPath);
            }
        }

        public ApplicationInfo(Application application, ApplicationPool applicationPool)
        {
            _application = application;
            _applicationPool = applicationPool;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
