using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BuilderPattern
{
	public class Person1
	{
		//address
		public string StreetAddress, Postcode, City;

		//employment
		public string CompanyName, Position;
		public int AnnualIncome;

		public override string ToString()
		{
			return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
		}
	}

	public class PersonBuilder1 //Facade
	{
		//Reference
		protected Person1 person = new Person1();

		public PersonJobBuilder1 Works => new PersonJobBuilder1(person);
		public PersonAddressBuilder1 Lives => new PersonAddressBuilder1(person);

		public static implicit operator Person1(PersonBuilder1 pb)
		{
			return pb.person;
		}
	}

	public class PersonJobBuilder1 : PersonBuilder1
	{
		public PersonJobBuilder1(Person1 person)
		{
			this.person = person;
		}

		public PersonJobBuilder1 At(string companyName)
		{
			person.CompanyName = companyName;
			return this;
		}

		public PersonJobBuilder1 AsA(string position)
		{
			person.Position = position;
			return this;
		}

		public PersonJobBuilder1 Earning(int amount)
		{
			person.AnnualIncome = amount;
			return this;
		}
	}
	public class PersonAddressBuilder1 : PersonBuilder1
	{
		public PersonAddressBuilder1(Person1 person)
		{
			this.person = person;
		}

		public PersonAddressBuilder1 At(string streetAddress)
		{
			person.StreetAddress = streetAddress;
			return this;
		}

		public PersonAddressBuilder1 WithPostcode(string postcode)
		{
			person.Postcode = postcode;
			return this;
		}

		public PersonAddressBuilder1 In(string city)
		{
			person.City = city;
			return this;
		}
	}

	public static class FacetedBuilder
    {
		public static void run()
		{
			var pb = new PersonBuilder1();
			Person1 person = pb
				.Lives.At("123, Main Street")
				      .In("St Julians")
					  .WithPostcode("STJ 123")
				.Works.At("GiG")
					  .AsA("Developer")
				      .Earning(10);

			Console.WriteLine(person);
		}
    }
}
