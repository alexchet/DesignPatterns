using System;
using System.Collections.Generic;
using System.Text;
using DesignPatterns.SolidDesignPrinciples;
using DesignPatterns.BuilderPattern;
using DesignPatterns.FactoryPattern;

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
			//InterfaceSegregationPrinciple.run();
			//DependencyInversionPrinciple.run();

			//Builder Pattern
			//Builder.run();
			//FluentBuilderInheritanceRecursiveGenerics.run();
			//FacetedBuilder.run();

			//Factory Pattern
			//Factory.run();
			AbstractFactory.run();

			if (System.Diagnostics.Debugger.IsAttached) Console.ReadKey();
		}
    }
}
