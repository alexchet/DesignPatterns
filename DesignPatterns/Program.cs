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
			//Solid Desgin Principles
			//SingleResponsibilityPrinciple.run();
			//OpenClosedPrinciple.run();
			//LiskovSubstitutionPrinciple.run();
			InterfaceSegregationPrinciple.run();

			if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
		}
    }
}
