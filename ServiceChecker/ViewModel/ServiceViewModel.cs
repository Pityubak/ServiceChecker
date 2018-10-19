using ServiceChecker.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Windows;

namespace ServiceChecker.ViewModel
{
    class ServiceViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<ServiceModel> services;
        public ObservableCollection<ServiceModel> Services {
            get
            {
                return services;
            }
            set
            {
                services = value;
                OnPropertyChanged(nameof(Services));
            }
        }
        private ServiceModel selectedModel;
        private ServiceHandler handler;

        public event PropertyChangedEventHandler PropertyChanged;

        public SpecCommand StopStartCommand { get; set; }
        public ServiceModel SelectedModel {
            get
            {
                return selectedModel;
            }
            set
            {
                    selectedModel = value;
                    StopStartCommand.RaiseCanExecuteChanged();
            }
        }

        public ServiceViewModel()
        {
            handler = new ServiceHandler();
            StopStartCommand = new SpecCommand(StatusChange,CanStatusChange);
            Refresh();
            
        }
      
        public void Refresh()
        {
            List<ServiceController> sc = new ServiceHandler().GetServices();
            ObservableCollection<ServiceModel> services = new ObservableCollection<ServiceModel>();

            foreach (var item in sc)
            {
                ServiceModel model = new ServiceModel
                {
                    DisplayName = item.DisplayName,
                    ServiceName = item.ServiceName,
                    Status = item.Status.ToString(),
                    Color = item.Status == ServiceControllerStatus.Running ? "LightGreen" : "LightPink",
                    Btntext = item.Status == ServiceControllerStatus.Running ? "Stop" : "Start"

                };

                services.Add(model);

            }
            Services = services;
        }
        public void StatusChange()
        {
            if (SelectedModel.Status == ServiceControllerStatus.Running.ToString())
            {
                handler.ServiceStop(SelectedModel.ServiceName);
            }
            else
            {
                handler.ServiceStart(SelectedModel.ServiceName);
            }
            Refresh();
        }
        public bool CanStatusChange()
        {
            return SelectedModel != null;
        }

        protected void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
