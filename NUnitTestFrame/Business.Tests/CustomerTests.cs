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

		[Test]
		//Через шпиона происходит проверка метод CalculateWage вызывает класс WorkingStatistics() с правильным Id 
		public void CalculateWage_PassesCorrectId()
		{
			const int id = 1;

			DbGateWaySpy gateWaySpy = new DbGateWaySpy();
			gateWaySpy.SetWorkingStatistics(new WorkingStatistics());
			Customer customer = new Customer(gateWaySpy, new LoggerDummy());
			customer.CalculateWage(id);

			Assert.That(id, Is.EqualTo(gateWaySpy.Id));
		}

		[Test]
		// Через подставку происходит проверка метод CalculateWage вызывает класс WorkingStatistics() с правильным Id 
		public void CalculateWage_Mock_PassesCorrectId()
		{
			const int id = 1;
			DbGateWayMock gateWayMock = new DbGateWayMock();
			gateWayMock.SetWorkingStatistics(new WorkingStatistics());

			Customer customer = new Customer(gateWayMock, new LoggerDummy());
			customer.CalculateWage(id);

			Assert.IsTrue(gateWayMock.VeryfiedCalledWithPropertyId(id));
		}

		[Test]
		// Через подделку происходит проверка метод CalculateWage вызывает класс WorkingStatistics() с правильным Id 
		public void CalculateWage_Fake_PassesCorrectId()
		{
			const int id = 1;
			DbGateWayFake gateWayFake = new DbGateWayFake();
			Customer customer = new Customer(gateWayFake, new LoggerDummy());
			customer.CalculateWage(id);

			Assert.IsTrue(gateWayFake.VeryfiedCalledWithPropertyId(id));
		}
		[Test]
		public void CalculateWageFake_HourlyPayed_ReturnsCorrectWage()
		{
			DbGateWayFake gateWayFake = new DbGateWayFake();
			Customer customer = new Customer(gateWayFake, new LoggerDummy());
			const int anyId = 1;
			decimal actualWage = customer.CalculateWage(anyId);
			const decimal expectedWage = 5 * 10;

			Assert.That(actualWage, Is.EqualTo(expectedWage).Within(0.1));
		}
	}
}
