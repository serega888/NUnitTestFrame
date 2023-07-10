using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
	[TestFixture]
	public class CalculatorTests
	{
		[Test]
		[TestCase(5, 4, 9)]
		public void AddNumbers_ValidValues_ReturnsCorrectResult(int a, int b, int c)
		{
			var calculator = new Calculator(a, b);
			int result = calculator.AddNumbers();

			Assert.That(result, Is.EqualTo(c));
		}

	}
}
