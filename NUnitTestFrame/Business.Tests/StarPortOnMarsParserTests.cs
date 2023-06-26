using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
	[TestFixture]
	public class StarPortOnMarsParserTests
	{
		[Test]
		public void ParsePort_MARS8_Returns8()
		{
			int result = StarPortOnMarsParser.ParsePort("MARS8");
			Assert.That(result, Is.EqualTo(8));

			//----------------------------------older style of Asserts in NUnit----------------------------
			//Assert.AreEqual(8, result);
		}
	}
}
