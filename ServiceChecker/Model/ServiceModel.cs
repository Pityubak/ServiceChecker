using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceChecker.Model
{
    class ServiceModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string displayName;
        private string serviceName;
        private string status;
        private string color;
        private string btntext;

        public string Btntext
        {
            get
            {
                return btntext;
            }
            set
            {
                if (value != btntext)
                {
                    btntext=value;
                    OnPropertyChanged(nameof(Btntext));
                }
            }
        }
   

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != color)
                {
                    color = value;
                    OnPropertyChanged(nameof(Color));
                }
            }
        }


        public string DisplayName
        {
            get
            {
                return displayName;
            }
            set
            {
                if (value != displayName)
                {
                    displayName = value;
                    OnPropertyChanged(nameof(DisplayName));
                }
            }
        }


        public string ServiceName
        {
            get
            {
                return serviceName;
            }
            set
            {
                if (value != serviceName)
                {
                    serviceName = value;
                    OnPropertyChanged(nameof(ServiceName));
                }
            }
        }


        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if (value != status)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string property=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
