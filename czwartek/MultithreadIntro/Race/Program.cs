using System;
using System.Threading;

namespace Race
{
    class Program
    {
       
        static void Main2(string[] args)
        {
            SpeedwayRace race = new SpeedwayRace(4, 30000);
            race.StartRace(new string[] { "Adam", "Marian", "Zenon", "Kamil" });
        }


        static void Main(string[] a)
        {
            Barrier b = new Barrier(2, (b) => { 
                Thread.Sleep(2000); 
                Console.WriteLine("Zakończono metodę bariery"); 
            });

            BarrierTest b1 = new BarrierTest(b);
            b1.Start();
            b1 = new BarrierTest(b);
            b1.Start();
        }

    }
}
