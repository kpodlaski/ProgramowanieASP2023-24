using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadIntro
{
    class Tester
    {
        Counter counter;
        public Tester(Counter c) { this.counter = c; }
        public void Test()
        {
            long t;
            while (true)
            {
                t = counter.GetState(); 
                
                if (t % 2 != 0)
                {
                    Console.WriteLine("ERRRORRRR !!! " + counter.GetState() + " -- " +t);
                    throw new Exception("--------");
                }
            }
        }

        public void StartTesting()
        {
            Thread t = new Thread(new ThreadStart(this.Test));
            t.Start();
        }
    }
}
