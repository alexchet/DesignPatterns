﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SolidDesignPrinciples
{
	public enum Color
	{
		Red, Green, Blue
	}

	public enum Size
	{
		Small, Medium, Large, Yuge
	}

	public class Product
	{
		public string Name;
		public Color Color;
		public Size Size;

		public Product(string name, Color color, Size size)
		{
			if (name == null)
				throw new ArgumentNullException(paramName: nameof(name));

			Name = name;
			Color = color;
			Size = size;
		}

		public override string ToString()
		{
			return $" - {Name} is {Color} and {Size}";
		}
	}

	public interface ISpecification<T>
	{
		bool IsSatisfied(T t);
	}

	public interface IFilter<T>
	{
		IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
	}

	public class ColorSpecification : ISpecification<Product>
	{
		private Color color;

		public ColorSpecification(Color color)
		{
			this.color = color;
		}

		public bool IsSatisfied(Product t)
		{
			return t.Color == color;
		}
	}

	public class SizeSpecification : ISpecification<Product>
	{
		private Size size;

		public SizeSpecification(Size size)
		{
			this.size = size;
		}

		public bool IsSatisfied(Product t)
		{
			return t.Size == size;
		}
	}

	public class AndSpecification<T> : ISpecification<T>
	{
		private ISpecification<T> first, second;

		public AndSpecification(ISpecification<T> first, ISpecification<T> second)
		{
			this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
			this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
		}

		public bool IsSatisfied(T t)
		{
			return first.IsSatisfied(t) && second.IsSatisfied(t);
		}
	}

	public class ProductFilter : IFilter<Product>
	{
		public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
		{
			foreach (var i in items)
				if (spec.IsSatisfied(i))
					yield return i;
		}
	}

	public static class OpenClosedPrinciple
    {
		public static void run()
		{
			var apple = new Product("Apple", Color.Green, Size.Small);
			var tree = new Product("Tree", Color.Green, Size.Large);
			var house = new Product("House", Color.Blue, Size.Large);
			var tower = new Product("Tower", Color.Blue, Size.Large);

			Product[] products = { apple, tree, house, tower };

			var pf = new ProductFilter();
			Console.WriteLine("Green Products: ");
			foreach (var p in pf.Filter(products, new ColorSpecification(Color.Green)))
			{
				Console.WriteLine(p.ToString());
			}

			Console.WriteLine("Large blue items: ");
			foreach (var p in pf.Filter(products, new AndSpecification<Product>(
					new ColorSpecification(Color.Blue),
					new SizeSpecification(Size.Large)
					)))
			{
				Console.WriteLine(p.ToString());
			}
		}
    }
}
