using Business.TestDouble.Testable;
using Business.Tests.TestDoubles;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.Extensions;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
	[TestFixture]
	public class CustomerTestsWithMockingFrameworkNSubstitute
	{

		[Test]
		public void CalculateWage_HourlyPayed_ReturnsCorrectWage()
		{
			var gateway = Substitute.For<IDbGateway>();
			var workingStatistics = new WorkingStatistics() { PayHourly = true, HourSalary = 100, WorkingHours = 10 };
			const int anyId = 1;
			//gateway.GetWorkingStatistics(anyId).ReturnsForAnyArgs(workingStatistics);
			gateway.GetWorkingStatistics(Arg.Any<int>()).ReturnsForAnyArgs(workingStatistics);
			gateway.Connected.Returns(true);

			const decimal expectedWage = 10 * 100;
			Customer customer = new Customer(gateway, Substitute.For<ILogger>());
			decimal actualWage = customer.CalculateWage(anyId);

			Assert.That(actualWage, Is.EqualTo(expectedWage).Within(0.1));
		}

		[Test]
		// Через подделку NSubstitute происходит проверка метод CalculateWage вызывает класс WorkingStatistics() с правильным Id 
		public void CalculateWage_MockNSubstitute_PassesCorrectId()
		{
			const int id = 1;
			var gateway = Substitute.For<IDbGateway>();
			gateway.GetWorkingStatistics(id).ReturnsForAnyArgs(new WorkingStatistics());
			Customer customer = new Customer(gateway, Substitute.For<ILogger>());
			customer.CalculateWage(id);

			gateway.Received().GetWorkingStatistics(id);
		}

		[Test]
		public void CalculateWage_ThrowsException_Return0()
		{
		    
		    var gateway = Substitute.For<IDbGateway>();
			gateway.GetWorkingStatistics(Arg.Any<int>()).Throws<InvalidOperationException>();

			var customer = new Customer(gateway, Substitute.For<ILogger>());
			const int anyId = 1;
			var actualWage = customer.CalculateWage(anyId);

			Assert.That(actualWage, Is.EqualTo(0));
		}

	}
}
