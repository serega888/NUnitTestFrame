using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
	[TestFixture]
	public class DeviceTests
	{
		[Test]
		public void Connect_FailedThrice_ThreeTries()
		{
			IProtocol provider = Substitute.For<IProtocol>();
			provider.Connect(Arg.Any<string>()).ReturnsForAnyArgs(false);

			var device = new Device(provider);
			device.Connect(String.Empty);

			provider.Received(3).Connect(Arg.Any<string>());
		}

		[Test]
		public void Find_FoundCOM8_ReturnsCOM8()
		{
			IProtocol provider = Substitute.For<IProtocol>();
			var device = new Device(provider);
			Task<string> task = device.Find();

			const string portName = "COM8";

			provider.SearchingFinished += Raise.Event<EventHandler<DeviceSearchingEventArgs>>(provider, new DeviceSearchingEventArgs(portName));

			Assert.That(task.Result, Is.EqualTo(portName));
		}

	}
}
