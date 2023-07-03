using Business.TestDouble.Testable;
using Business.Tests.TestDoubles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
	[TestFixture]
	public class CustomerTests
	{
		[Test]
		public void CalculateWage_HourlyPayed_ReturnsCorrectWage()
		{
			DbGateWayStub gateWayStub = new DbGateWayStub();
			gateWayStub.SetWorkingStatistics(new WorkingStatistics()
			{
				PayHourly = true,
				HourSalary = 100,
				WorkingHours = 10,
			});
			Customer customer = new Customer(gateWayStub, new LoggerDummy());
			const int anyId = 1;
			decimal actual = customer.CalculateWage(anyId);
			const decimal expectedWage = 100 * 10;

			Assert.That(actual, Is.EqualTo(expectedWage).Within(0.1));

		}
	}
}
