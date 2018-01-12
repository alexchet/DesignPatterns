using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BuilderPattern
{
	public class Person
	{
		public string Name;
		public string Positon;

		public class Builder : PersonJobBuilder<Builder>
		{
		}

		public static Builder New => new Builder();

		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(Positon)}: {Positon}";
		}
	}

	public abstract class PersonBuilder
	{
		protected Person person = new Person();

		public Person Build()
		{
			return person;
		}
	}

	//class Foo : Bar<Foo>
	public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
	{
		public SELF Called(string name)
		{
			person.Name = name;
			return (SELF) this;
		}
	}

	public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
	{
		public SELF WorkAsA(string position)
		{
			person.Positon = position;
			return (SELF) this;
		}
	}

	public static class FluentBuilderInheritanceRecursiveGenerics
	{
		public static void run()
		{
			Person me = Person.New
				.Called("Alex")
				.WorkAsA("Developer")
				.Build();

			Console.WriteLine(me);
		}
	}
}
