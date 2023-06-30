using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[SetUpFixture]
class AssemblySetUpTearDown
{
	[OneTimeSetUp]
	public void AssemblySetUp()
	{
		Trace.WriteLine("Assembly setup");
	}

	[OneTimeTearDown]
	public void AssemblyTearDown()
	{
		Trace.WriteLine("Assembly teardown");
	}
}

namespace Business.Tests
{
	[SetUpFixture]
	class NameSpaceSetUpTearDown
	{
		[OneTimeSetUp]
		public void NameSpaceSetUp()
		{
			Trace.WriteLine("NameSpace setup");
		}

		[OneTimeTearDown]
		public void NameSpaceTearDown()
		{
			Trace.WriteLine("NameSpace teardown");
		}
	}

}
