using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Delegates
{
    public class Test4
    {
        delegate int TestDelegate(int a);
        delegate int Test2Delegate(int a,int b);
        public void PerformTest()
        {
            //Using Anonymous functions
            TestDelegate func = delegate(int k) {
                return k * 2;
            };

            var result = func(5);
            Console.WriteLine("Result is:{0}", result);

            //Using Lambda Expression
            TestDelegate func1 = (x => x * 2);

            result = func1(7);
            Console.WriteLine("Result is:{0}", result);


            //Lambda Expression (multiple input parameters, multiple statements body)
            Test2Delegate func2 = (x, y) => {
                if (x > y)
                    return x;
                else
                    return y;
            };

            result = func2(7,10);
            Console.WriteLine("Result is:{0}", result);

            //Lambda Expression with Closure
            int z = 20;
            TestDelegate func3 = (x => x * z);

            result = func3(5);
            Console.WriteLine("Result is:{0}", result);

            
            //Predicate example
            int[] data = {5,10,20,30 };

            /*
             * Signature of 'Predicate<T>' delegate
             * public delegate bool Predicate<T>(T obj);
            */

            result = Array.Find(data, FindMod);
            Console.WriteLine("Result is:{0}", result);


            result = Array.Find(data, (x => x % 4 == 0));

            Console.WriteLine("Result is:{0}", result);


            result = CustomFind(data, (x => x % 4 == 0));
            Console.WriteLine("Result is:{0}", result);
        }

        private Boolean FindMod(int a)
        {
            if (a % 4 == 0)
                return true;
            else
                return false;
        }

        int CustomFind(int[] data, Predicate<int> p)
        {
            for (int i = 0; i < data.Count(); i++)
            {
                if (p(data[i]) == true)
                    return data[i];
            }

            return -1;
        }

    }
}
