using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race
{
    class BarrierTest
    {
        Barrier barrier;

        public BarrierTest(Barrier b)
        {
            this.barrier = b;
        }

        public void Start()
        {
            Thread t = new Thread(new ThreadStart(Run));
            t.Start();
        }

        private void Run()
        {
            Console.WriteLine("Dochodzę do bariery");
            barrier.SignalAndWait();
            Console.WriteLine("Koniec pracy");
        }
    }
}
