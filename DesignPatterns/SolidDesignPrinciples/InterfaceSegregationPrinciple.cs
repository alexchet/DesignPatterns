using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SolidDesignPrinciples
{
	public class Document
	{

	}

	public interface iMachine
	{
		void Print(Document d);
		void Scan(Document d);
		void Fax(Document d);
	}

	public class MultiFunctionPrinter : iMachine
	{
		public void Fax(Document d)
		{
			throw new NotImplementedException();
		}

		public void Print(Document d)
		{
			throw new NotImplementedException();
		}

		public void Scan(Document d)
		{
			throw new NotImplementedException();
		}
	}

	public class OldFashionPrinter : iMachine
	{
		public void Fax(Document d)
		{
			throw new NotImplementedException();
		}

		public void Print(Document d)
		{
			throw new NotImplementedException();
		}

		public void Scan(Document d)
		{
			throw new NotImplementedException();
		}
	}

	public interface IPrinter
	{
		void Print(Document d);
	}
	public interface IScanner
	{
		void Scan(Document d);
	}

	public class Photocopier : IPrinter, IScanner
	{
		public void Print(Document d)
		{
			Console.WriteLine("Printing...");
		}

		public void Scan(Document d)
		{
			Console.WriteLine("Scanning...");
		}
	}

	public class Printer : IPrinter
	{
		public void Print(Document d)
		{
			Console.WriteLine("Printing...");
		}
	}


	public class Scanner : IScanner
	{
		public void Scan(Document d)
		{
			Console.WriteLine("Scanning...");
		}
	}

	public interface IMultiFunctionDevice : IScanner, IPrinter
	{

	}

	public class MultiFunctionMachine : IMultiFunctionDevice
	{
		private IPrinter printer;
		private IScanner scanner;

		public MultiFunctionMachine(IPrinter printer, IScanner scanner)
		{
			if (printer == null)
				throw new ArgumentNullException(paramName: nameof(printer));
			if (scanner == null)
				throw new ArgumentNullException(paramName: nameof(scanner));

			this.printer = printer;
			this.scanner = scanner;
		}

		public void Print(Document d)
		{
			printer.Print(d);
		}
		public void Scan(Document d)
		{
			scanner.Scan(d);
		} //decorator
	}

	public static class InterfaceSegregationPrinciple
	{
		public static void run()
		{
			Document d = new Document();
			IPrinter printer = new Printer();
			IScanner scanner = new Scanner();

			MultiFunctionMachine m = new MultiFunctionMachine(printer, scanner);
			m.Print(d);
			m.Scan(d);
		}
    }
}
