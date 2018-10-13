using System;
using System.IO;


namespace EsetChecker
{
    class SimpleLogger
    {
        private readonly string savePath;

        public SimpleLogger(string savePath)
        {
            this.savePath = savePath;
        }

        public void Log(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(savePath + "\\" + DateTime.Now.ToShortDateString() + ".log"))
                {
                    sw.WriteLine(message);
                }
            }
            catch (Exception)
            {
                
            }
          
        }
    }
}
