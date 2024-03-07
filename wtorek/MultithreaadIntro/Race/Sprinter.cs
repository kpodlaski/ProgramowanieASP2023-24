using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race
{
    class Sprinter
    {
        public String Name { get; private set; }
        Race race;
        static Random random = new Random();
        double v = 0.0;
        public long finishTime { get; private set; }

        public Sprinter(String name, Race race)
        {
            this.Name = name;
            this.race = race;
        }

        private void racing()
        {
            approachStartLine();
            race.StartLine.SignalAndWait();
            runInRace();
            race.EndLine.SignalAndWait();
            finishRace();
        }

        private void finishRace()
        {
            Console.WriteLine("Sprinter {0} going out of the stadium", Name);
            Console.WriteLine("Sprinter {0} mean speed {1}", Name, v);
        }

        private void runInRace()
        {
            double x = 0.0;
            while (x < race.Distance)
            {
                x += v;
            }
            finishTime = DateTime.Now.Ticks;
        }

        private void approachStartLine()
        {
            lock (random)
            {
                v = random.NextDouble() * 3 + 0.2;
            }
            Console.WriteLine("Sprinter {0} approached start line", Name);
        }

        public void StartRace()
        {
            Thread t = new Thread(new ThreadStart(racing));
            t.Start();
        }
    }
}
