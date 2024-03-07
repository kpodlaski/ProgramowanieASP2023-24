using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadIntro
{
    class Counter
    {
        string Name;
        private long state;
        public Counter(string Name)
        {
            this.Name = Name;
        }
        public void Count()
        {
            while (true)
            {
                lock (this)
                {
                    IncreaseState();
                    IncreaseState();
                }
                //if (state > 50) break;
                //Console.WriteLine(Name + " " + state);
            }
        }

        public long GetState()
        {
            lock (this)
            {
                return state;
            }
        }

        public void IncreaseState()
        {
            lock (this)
            {
                state += 1;
            }
        }

        public void Run()
        {
            Thread t = new Thread(new ThreadStart(this.Count));
            t.Start();
        }
    }
}
