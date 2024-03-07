using System;

namespace MultithreadIntro
{

	public class Counter
	{
		String Name;
		long c = 0;

		public Counter(string name)
		{
			this.Name = name;
	
		}

		public void Count()
        {
            while (true)
            {
				this.c += 1;
				this.c += 1;
				Console.WriteLine(Name + " " + c);
				if (c > 50) break;
			}
        }
	}
}




