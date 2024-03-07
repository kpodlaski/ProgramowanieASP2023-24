using System;
using System.Threading;

namespace MultithreaadIntro
{
    class Program
    {
        static void Main2(string[] args)
        {
            Counter c = new Counter("w1");
            //Counter c2 = new Counter("w2");
            Tester t = new Tester(c);
            t.startTester();
            c.startCounting();
            //c2.startCounting();
            //Console.WriteLine("Koniec programu");
        }

        static void Main(string[] args)
        {
            VisitCounter vc = new VisitCounter();
            Visitor v = new Visitor(vc);
            for (int i = 0; i < 3; i++)
            {
                Thread t = new Thread(new ThreadStart(v.Run));
                t.Start();
            }
            Thread.Sleep(3000);
            Console.WriteLine(vc.CountedVisits());
        }
    }
}
