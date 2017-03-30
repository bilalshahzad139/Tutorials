using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace TestWindService
{
    public partial class MyTestService : ServiceBase
    {
        public MyTestService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("D:\\test.txt"))
            {
                writer.WriteLine("Application started at:" + DateTime.Now);
                writer.Close();
            }
        }

        protected override void OnStop()
        {
            using (StreamWriter writer = new StreamWriter("D:\\test.txt"))
            {
                writer.WriteLine("Application Stopped at:" + DateTime.Now);
                writer.Close();
            }
        }
    }
}
