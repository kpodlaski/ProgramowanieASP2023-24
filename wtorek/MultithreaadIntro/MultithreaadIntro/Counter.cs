using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreaadIntro
{
    class Counter
    {
        public long c { get; private set; }
        string name;

        public Counter(string name)
        {
            this.name = name;
            c = 0;
        }
        public void count()
        {
            while(true){
                lock (this)
                {
                    c += 1;
                    c += 1;
                    //Console.WriteLine("Z wątku "+name+": " + c);
                    //if (c > 50) break;
                }
            }
            //Console.WriteLine("Koniec wątku");
        }

        public void startCounting()
        {
            Thread t = new Thread(new ThreadStart(this.count));
            t.Start();
        }
    }
}
