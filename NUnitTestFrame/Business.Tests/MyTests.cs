using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
	[TestFixture]
	public class MyTests
	{
		#region All

		[Test]
		public void ConstraintAll()
		{
			string[] array = new string[] { "word", "world", "programmer" };

			Assert.That(array, Is.All.Contains("o"));

			int[] arrayTwo = new int[] { 10, 20, 30, 40, 50 };

			Assert.That(arrayTwo, Has.All.GreaterThan(8));
		}

		#endregion

		#region Not

		[Test]
		public void ConstraintNot()
		{
			string[] array = new string[] { "word", "world", "programmer" };

			Assert.That(array, Is.Not.Length.EqualTo(2));
			Assert.That(array, Is.Not.Null);

			string question = "Are you programmer?";

			Assert.That(question, Does.Not.EndWith("!"));
			Assert.That(question, Does.Not.Contain("word"));
		}

		#endregion

		#region Some

		[Test]
		public void ConstraintSome()
		{
			string[] array = new string[] { "word", "world", "programmer" };

			Assert.That(array, Has.Some.StartsWith("wo"));

			double[] arrayTwo = new double[] { 0.99, 2.2, 3.0, 4.05 };
			Assert.That(arrayTwo, Has.Some.EqualTo(1.0).Within(0.5));
		}

		#endregion

		#region Or And Not

		[Test]
		public void CompoundConstraintOrAndNot()
		{
			Assert.That(5, Is.LessThan(6).Or.GreaterThan(10));
			Assert.That(8, Is.LessThan(10).And.GreaterThan(1));
			Assert.That(9, Is.Not.GreaterThan(10));
		}

		#endregion
	}
}
