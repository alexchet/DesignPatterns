using System;
using System.Collections.Generic;
using System.Text;
using DesignPatterns.SolidDesignPrinciples;

namespace DesignPatterns
{
    public class Program
	{
		static void Main(string[] args)
		{
			SingleResponsibilityPrinciple.run();
			OpenClosedPrinciple.run();

			if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
		}
    }
}
