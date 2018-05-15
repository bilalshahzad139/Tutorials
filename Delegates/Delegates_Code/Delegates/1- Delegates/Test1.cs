using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    /* 
     * A delegate is a reference type variable that holds the reference to a method. 
     * The reference can be changed at runtime.
     */
    public delegate int MyFunc(int amount);

    class Test1
    {
        
        int SquareFinder(int number)
        {
            return (number * number);
        }
        int SquareFinder1(int number)
        {
            return (number * number);
        }

        public void PerformTest()
        {
            MyFunc f = new MyFunc(SquareFinder);
            var result = f(5);
            Console.WriteLine("Result is {0}", result );

            f = SquareFinder;
            result = f(6);
            Console.WriteLine("Result is {0}", result);


            //Multicasting of a Delegate
            f += SquareFinder1;
            result = f(7);
            Console.WriteLine("Result is {0}", result);

            f -= SquareFinder1;
            result = f(8);
            Console.WriteLine("Result is {0}", result);
        }

         public void PerformTest2()
         {
             /*
              * Anonymous methods provide a technique to pass a code block as a delegate parameter. 
              * Anonymous methods are the methods without a name, just the body.
             */

             MyFunc f = delegate(int a)
             {
                 return a * a;
             };

             var result = f(9);
             Console.WriteLine("Result is:{0}", result);


             f += delegate(int b)
             {
                 return b + b;
             };

             var result1 = f(5);
             Console.WriteLine("Result is:{0}", result1);

         }
    }
}
