using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreaadIntro
{
    class Tester
    {
        private Counter counter;

        public Tester(Counter counter)
        {
            this.counter = counter;
        }

        public void test()
        {
            while (true)
            {
                long cValue;
                lock (counter)
                {
                    cValue = counter.c;
                }
                if (cValue%2 != 0)
                {
                    Console.WriteLine("Wrong value, " + counter.c + ", " + cValue);
                    //Thread.Sleep(30);
                    throw new Exception("ERRRORRR");
                }
            }
        }
        public void startTester()
        {
            Thread t = new Thread(new ThreadStart(this.test));
            t.Start();
        }
    }
}
