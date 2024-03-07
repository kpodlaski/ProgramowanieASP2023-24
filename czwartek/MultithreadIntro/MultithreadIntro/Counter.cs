using System;
using System.Threading;

namespace MultithreadIntro
{

	public class Counter
	{
		String Name;
		public long c = 0;
		public Counter(string name)		{
			this.Name = name;
		}
		public void Count()		{
			while (true)
			{
				lock (this) {
					this.c += 1;
					this.c += 1;
				}
				//Console.WriteLine(Name + " " + c);
				//if (c > 50) break;
			}
		}
		public void Run()
        {
			Thread t = new Thread(
				new ThreadStart(this.Count));
			t.Start();
        }
	}
}




