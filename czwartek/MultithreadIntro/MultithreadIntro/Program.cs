using System;

namespace MultithreadIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c1 = new Counter("C1");
            Tester t = new Tester(c1);
            t.Run();
            c1.Run();
            Console.WriteLine("Koniec programu");
        }
    }
}
