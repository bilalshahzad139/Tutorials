using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Delegates
{
    //Events use the publisher-subscriber model.
    public delegate void CountToZeroHandler();

    public class Student
    {
        static int studentCount = 5;
        event CountToZeroHandler OnCountChange;

        public void SubscribeListener(CountToZeroHandler listener)
        {
            OnCountChange += new CountToZeroHandler(listener);
        }

        public void DecreaseCount()
        {
            studentCount--;
            if (studentCount <= 0)
            {
                if (OnCountChange != null)
                {
                    OnCountChange();
                }
            }
        }
    }

    public class Test3
    {
        public  void PerformTest()
        {
            Student std = new Student();

            std.SubscribeListener(Subscriber1);
            std.SubscribeListener(Subscriber2);

            for (int i = 0; i < 5; i++)
            {
                std.DecreaseCount();
            }
        }

        void Subscriber1()
        {
            Console.WriteLine("Suscriber1 is notified!");
        }
        void Subscriber2()
        {
            Console.WriteLine("Subscriber2 is notified!");
        }
    }
}
