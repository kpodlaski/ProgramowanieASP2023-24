using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreaadIntro
{
    class VisitCounter
    {
        private long counter = 0;

        public void Increase()
        {
            lock (this)
            {
                counter += 1;
            }
        }

        public long CountedVisits()
        {
            return counter;
        }
    }
}
