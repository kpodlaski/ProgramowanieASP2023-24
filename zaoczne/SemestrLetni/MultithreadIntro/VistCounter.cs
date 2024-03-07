using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadIntro
{
    class VistCounter
    {
        private volatile int counter = 0;

        public void NewVisitor()
        {
            lock (this)
            {
                counter++;
            }
        }

        public int HowManyVisitors()
        {
            return counter;
        }
    }
}
