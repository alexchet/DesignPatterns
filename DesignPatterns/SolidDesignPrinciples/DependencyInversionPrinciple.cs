using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.SolidDesignPrinciples
{
	public enum Relationship
	{
		Parent,
		Child,
		Sibling
	}

	public class Person
	{
		public string Name;
	}

	public interface IRelationshipBrowser
	{
		IEnumerable<Person> FindAllChildrenOf(string name);
		IEnumerable<Person> FindAllParentOf(string name);
	}

	//low-level
	public class Relationships : IRelationshipBrowser
	{
		private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

		public void AddParentAndChild(Person parent, Person child)
		{
			relations.Add((parent, Relationship.Parent, child));
			relations.Add((child, Relationship.Child, parent));
		}

		public IEnumerable<Person> FindAllChildrenOf(string name)
		{
			return relations.Where(
				x => x.Item1.Name == name &&
				x.Item2 == Relationship.Parent).Select(r => r.Item3);
		}

		public IEnumerable<Person> FindAllParentOf(string name)
		{
			return relations.Where(
				x => x.Item1.Name == name &&
				x.Item2 == Relationship.Child).Select(r => r.Item3);
		}

		public List<(Person, Relationship, Person)> Relations => relations;
	}

	public class Research
	{
		//public Research(Relationships relationships)
		//{
		//	var relations = relationships.Relations;
		//	foreach (var r in relations.Where(
		//		x => x.Item1.Name == "John" &&
		//		x.Item2 == Relationship.Parent))
		//	{
		//		Console.WriteLine($"John has a child called {r.Item3.Name}");
		//	}
		//}

		public Research(IRelationshipBrowser browser)
		{
			foreach (var p in browser.FindAllChildrenOf("John"))
				Console.WriteLine($"John has a child called {p.Name}");

			foreach (var p in browser.FindAllParentOf("David"))
				Console.WriteLine($"David has a parent called {p.Name}");
		}

		public static void run()
		{
			var parent1 = new Person { Name = "John" };
			var parent2 = new Person { Name = "Karen" };
			var child1 = new Person { Name = "David" };
			var child2 = new Person { Name = "Mary" };

			var relationships = new Relationships();
			relationships.AddParentAndChild(parent1, child1);
			relationships.AddParentAndChild(parent1, child2);
			relationships.AddParentAndChild(parent2, child1);
			relationships.AddParentAndChild(parent2, child2);

			new Research(relationships);
		}
	}

	public static class DependencyInversionPrinciple
	{
		public static void run()
		{
			Research.run();
		}
	}
}
