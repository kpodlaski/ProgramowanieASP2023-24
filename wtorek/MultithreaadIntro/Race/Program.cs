using System;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Race race = new Race(1000, new String[] { "Elana", "Helena", "Anna", "Maria" });
            race.StartRace();
        }
    }
}
