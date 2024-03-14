using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race
{
    class Racer
    {
        public String Name { get; private set; }
        private Barrier startLine;
        private Barrier endLine;
        private SpeedwayRace race;
        private static Random random = new Random();
        public long Time { get; private set; }
        private double vel;

        public Racer(String name,  SpeedwayRace race, Barrier startLine, Barrier endLine)
        {
            this.Name = name;
            this.race = race;
            this.startLine = startLine;
            this.endLine = endLine;
        }

        public void DoRace()
        {
            Thread t = new Thread(new ThreadStart(doRace));
            t.Start();
        }

        private void doRace()
        {
            prepare();
            startLine.SignalAndWait();
            start();
            endLine.SignalAndWait();
            goBackToParkingZone();
        }

        private void goBackToParkingZone()
        {
            Console.WriteLine("Zawodnik " + Name + " wraca na parking");
            Console.WriteLine(Name + " jechał z v=" + vel);
        }

        private void start()
        {
           
            double d = 0.0;
            while (d < race.Distance)
            {
                d += vel;
            }
            Time = DateTime.Now.Ticks;
        }

        private void prepare()
        {
            //Do some prepare operations
            Console.WriteLine("Zawodnik "+Name+ " pojawił się na lini startu");
            lock (random)
            {
                vel = random.NextDouble() * 3 + .5;
            }
        }
    }
}
