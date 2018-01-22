using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.FactoryPattern
{
	public interface IHotDrink
	{
		void Consume();
	}

	internal class Tea : IHotDrink
	{
		public void Consume()
		{
			Console.WriteLine("Tea is nice.");
		}
	}

	internal class Coffee : IHotDrink
	{
		public void Consume()
		{
			Console.WriteLine("Coffee is nice.");
		}
	}

	public interface IHotDrinkFactory
	{
		IHotDrink Prepare(int amount);
	}

	internal class TeaFactory : IHotDrinkFactory
	{
		public IHotDrink Prepare(int amount)
		{
			Console.WriteLine($"Put in a tea bag, boil water, pour {amount} ml.");
			return new Tea();
		}
	}

	internal class TeaFactory : IHotDrinkFactory
	{
		public IHotDrink Prepare(int amount)
		{
			Console.WriteLine($"Put in a tea bag, boil water, pour {amount} ml.");
			return new Tea();
		}
	}

	public static class AbstractFactory
    {
		public static void run()
		{
		}
    }
}
