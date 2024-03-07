using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadIntro
{
    class Visitor
    {
        private VistCounter vc;
        private Barrier barrier;

        public Visitor(VistCounter vc, Barrier barrier)
        {
            this.vc = vc;
            this.barrier = barrier;
        }

        public void Run()
        {
            for (int i = 0; i < 10000; i++)
                {
                    vc.NewVisitor();
                }
            Console.WriteLine("Odwiedzono 10000 razy");
            barrier.SignalAndWait();
        }

        public Thread GetVisitorThread()
        {
            return new Thread(new ThreadStart(this.Run));
        }
    }
}
