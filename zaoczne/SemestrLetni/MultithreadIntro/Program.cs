using System;
using System.Collections.Generic;
using System.Threading;

namespace MultithreadIntro
{
    class Program
    {
        public static void Main()
        {
            VistCounter vc = new VistCounter();
            Barrier barrier = new Barrier(3, 
                (b) =>{
                Console.WriteLine("Stan końcowy:" + vc.HowManyVisitors());
                }) ;
            Console.WriteLine("Stan początkowy:"+ vc.HowManyVisitors());
            List<Thread> threads = new List<Thread>();
            for (int i=0; i<3; i++)
            {
                Visitor v = new Visitor(vc, barrier);
                threads.Add(v.GetVisitorThread());
            }
            foreach(Thread t in threads)
            {
                t.Start();
            }
        }
        static void Main2(string[] args)
        {
            Counter c1 = new Counter("c1");
            Tester t = new Tester(c1);
            //Counter c2 = new Counter("c2");
            //Counter c3 = new Counter("c3");
            t.StartTesting();
            c1.Run();
            //c2.Run();
            //c3.Run();
            Console.WriteLine("Zakończono program");
        }
    }
}
