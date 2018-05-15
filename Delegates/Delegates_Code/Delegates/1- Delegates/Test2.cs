using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Delegates
{
    public delegate void WriteString(String s);

    public class MyStringWriter
    {
        WriteString writer = null;
        public MyStringWriter(WriteString writerFunc)
        {
            writer = writerFunc;
        }

        public void Subscribe(WriteString f)
        {
            writer += f;
        }

        public void Write(String s)
        {
            if (writer != null)
            {
                writer(s);
            }
        }
    }//end of StringWriter

    public class Test2
    {
        void ConsoleWriter(String s)
        {
            Console.WriteLine(s);
        }
        void FileWriter(String s)
        {
            using (StreamWriter objStream = new StreamWriter("D:\\test.txt"))
            {
                objStream.Write(s);
                objStream.Close();
            }
        }

        public void PerformTest()
        {
            MyStringWriter obj1 = new MyStringWriter(ConsoleWriter);
            obj1.Subscribe(FileWriter);

            //MyStringWriter obj2 = new MyStringWriter(FileWriter);

            obj1.Write("Hello World");
            
            //obj2.Write("Hello World");

        }
    }
}
