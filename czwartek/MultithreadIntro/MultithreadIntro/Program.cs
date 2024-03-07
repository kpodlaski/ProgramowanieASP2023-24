using System;
using System.Threading;

namespace MultithreadIntro
{
    class Program
    {

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

        static void Main2(string[] args)
        {
            Counter c1 = new Counter("C1");
            Tester t = new Tester(c1);
            t.Run();
            c1.Run();
            Console.WriteLine("Koniec programu");
        }
    }
}
