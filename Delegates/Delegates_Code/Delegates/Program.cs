using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    class Program
    {

        static void Main(string[] args)
        {
            
            //Delegates, Anonymous functions
            Test1 obj = new Test1();
            obj.PerformTest();
            obj.PerformTest2();
            /*
            //Example of using Delegates
            Test2 obj2 = new Test2();
            obj2.PerformTest();

            //Example of uisng Events
            Test3 obj3 = new Test3();
            obj3.PerformTest();
            

            //Example of Lambda Expressions
            Test4 obj4 = new Test4();
            obj4.PerformTest();
            

            //Example of IEnumerable, IEnumerator

            Test5 obj5 = new Test5();
            obj5.PerformTest();
            */
            Console.ReadKey();
                
        }

         
    }
}
