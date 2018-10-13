using System;
using System.Linq;
using System.ServiceProcess;


namespace EsetChecker
{
    class ServiceHandler
    {
        private readonly string serviceName;

        public ServiceHandler(string serviceName)
        {
            this.serviceName = serviceName;
        }

        public string ServiceName => serviceName;

        public bool ServiceExists()
        {
            return ServiceController.GetServices().Any(p => p.ServiceName.Equals(ServiceName));
        }
        public bool ServiceRunning()
        {
            using(ServiceController sc=new ServiceController())
            {
                sc.ServiceName = serviceName;
                if (sc.Status == ServiceControllerStatus.Running)
                    return true;
                else
                    return false;
            }
        }
        public void ServiceStart()
        {
            using(ServiceController sc=new ServiceController())
            {
                sc.ServiceName = ServiceName;
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    try
                    {
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                    }
                    catch (Exception op)
                    {
                        new SimpleLogger(AppDomain.CurrentDomain.BaseDirectory).Log(op.Message);
                    }
                }
            }
        }
        public void ServiceStop()
        {
            using (ServiceController sc = new ServiceController())
            {
                sc.ServiceName = ServiceName;
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    try
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped);
                    }
                    catch (Exception op)
                    {
                        new SimpleLogger(AppDomain.CurrentDomain.BaseDirectory).Log(op.Message);
                    }
                }
            }
        }
    }
}
