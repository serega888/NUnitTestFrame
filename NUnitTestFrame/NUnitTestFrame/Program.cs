using Business;

namespace NUnitTestFrame
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, NUnitTestFramework!");
			Console.WriteLine(StarPortOnMarsParser.ParsePort("MARS8"));
		}
	}
}