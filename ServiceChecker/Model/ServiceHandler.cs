using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;


namespace ServiceChecker.Model
{
    class ServiceHandler
    {

        public ServiceHandler() { }

        public List<ServiceController> GetServices()
        {
            return ServiceController.GetServices().ToList();
        }
        public bool ServiceExists(string servicename)
        {
            return ServiceController.GetServices().Any(p => p.ServiceName.Equals(servicename));
        }
        public bool ServiceRunning(string servicename)
        {
            using(ServiceController sc=new ServiceController())
            {
                sc.ServiceName = servicename;
                if (sc.Status == ServiceControllerStatus.Running)
                    return true;
                else
                    return false;
            }
        }
        public void ServiceStart(string servicename)
        {
            using(ServiceController sc=new ServiceController())
            {
                sc.ServiceName = servicename;
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    try
                    {
                        sc.Start();
                        sc.Refresh();
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                    }
                    catch (Exception op)
                    {
                        new SimpleLogger(AppDomain.CurrentDomain.BaseDirectory).Log(op.Message);
                    }
                }
            }
        }
        public void ServiceStop(string servicename)
        {
            using (ServiceController sc = new ServiceController())
            {
                sc.ServiceName = servicename;
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    try
                    {
                        sc.Stop();
                        sc.Refresh();
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
