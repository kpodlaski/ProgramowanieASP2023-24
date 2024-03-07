using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreaadIntro
{
    class Visitor
    {
        VisitCounter vCounter;

        public Visitor(VisitCounter counter)
        {
            this.vCounter = counter;
        }


        public void Run() {
            for (int i=0; i<10000; i++)
            {
                vCounter.Increase();
            }
            Console.WriteLine("Skończyłem");
        }

    }
}
