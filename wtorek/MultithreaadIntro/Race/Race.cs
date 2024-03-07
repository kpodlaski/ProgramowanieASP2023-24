using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race
{
    class Race
    {
        internal Barrier StartLine { get; private set; }
        internal Barrier EndLine { get; private set;}
        public double Distance { get; internal set; }
        private List<Sprinter> sprinters = new List<Sprinter>();
        private long startingTime;

        public Race(double distance, String[] racerNames)
        {
            this.Distance = distance;
            StartLine = new Barrier(racerNames.Length, (b) =>
            {
                startingTime = DateTime.Now.Ticks;
            });

            EndLine = new Barrier(racerNames.Length, (b) =>
            {
                Console.WriteLine("Wyniki :");
                foreach(Sprinter s in sprinters) {
                    Console.WriteLine("Sprinter {0} result {1}", s.Name, s.finishTime - startingTime);
                }
            });

            foreach (String name in racerNames)
            {
                Sprinter s = new Sprinter(name, this);
                sprinters.Add(s);
            }
        }

        public void StartRace()
        {
            foreach (Sprinter s in sprinters)
            {
                s.StartRace();
            }
        }
    }
}
