using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WCF_TestApp.CustomerServiceManager;

namespace WCF_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerServiceClient client = new CustomerServiceClient();
            var result = client.GetMonths(10);

            Console.WriteLine("Months:{0}", result);

            Console.ReadKey();
        }
    }
}
