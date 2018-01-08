using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatterns.SolidDesignPrinciples
{
	public class Journal
	{
		private readonly List<string> entries = new List<string>();

		private static int count = 0;

		public int AddEntry(string text)
		{
			entries.Add($"{++count}: {text}");
			return count; //memento
		}

		public void RemoveEntry(int index)
		{
			entries.RemoveAt(index);
		}

		public override string ToString()
		{
			return string.Join(Environment.NewLine, entries);
		}
	}

	public class Persistence
	{
		public void SaveToFile(Journal j, string filename, bool overwrite = false)
		{
			if (overwrite || !File.Exists(filename))
				File.WriteAllText(filename, j.ToString());
		}

	}

    public static class SingleResponsibilityPrinciple
    {
        public static void run()
		{
			var j = new Journal();
			j.AddEntry("Today is Moday");
			j.AddEntry("Lunch is soon served");
			Console.WriteLine(j);

			var p = new Persistence();
			var filename = @"..\journal.txt";
			p.SaveToFile(j, filename, true);
		}
    }
}
