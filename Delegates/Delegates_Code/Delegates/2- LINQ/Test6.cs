using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public String CustomerName { get; set; }
        public Customer(int id, String n)
        {
            CustomerID = id;
            CustomerName = n;
        }
        
    }
    public class Test6
    {
        public void PerformTest()
        {
            int [] data = {5,10,20,30,40};

            //Here result is IEnumerable
            var result = (from d in data
                          where d > 20
                         select d);

            var count = result.Count();
            var max = result.Max();
            var min = result.Min();
            
            //as result is IEnumerable type, it can also be iterated 
            foreach (var r in result)
            {
                Console.WriteLine("Value is:{0}", r);
            }

            List<Customer> CustomerList = new List<Customer>
            {
                new Customer(1,"ABC"),
                new Customer(2,"XYZ"),
                new Customer(3,"MNL"),
                new Customer(4,"CDE"),
            };


            var cust = CustomerList.Where(p => p.CustomerID == 1).FirstOrDefault();

            var sorted = CustomerList.OrderBy(p => p.CustomerName).ToList();



        }

    }
}
