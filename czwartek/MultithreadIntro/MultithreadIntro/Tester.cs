using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadIntro
{
    class Tester    {
        Counter counter;
        public Tester(Counter counter)        {
            this.counter = counter;
        }
        
        public void Test()        {
            long t;
            while (true)
            {
                lock (this.counter)
                {
                    t = counter.c;
                }
                if (t % 2 != 0)
                {
                    break;
                }
            }
            Console.WriteLine("Errroor!!! " + counter.c
                + " : "+t);
            throw new Exception("We have problem");
        }
        
        public void Run()
        {
            Thread t = new Thread(new ThreadStart(this.Test));
            t.Start();
        }
    }
}
