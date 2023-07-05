using Business.TestDouble.Testable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.TestDoubles
{
	public class DbGateWayFake : IDbGateway
	{
		private Dictionary<int, WorkingStatistics> _getWorkingStatistics = new Dictionary<int, WorkingStatistics>()
		{
			{1, new WorkingStatistics() {PayHourly = true, WorkingHours = 5, HourSalary = 10}},
			{2, new WorkingStatistics() {PayHourly = false, MonthSalary = 800}},
			{3, new WorkingStatistics() {PayHourly = true, WorkingHours = 8, HourSalary = 100}},	
		};

		public int Id { get; private set; }

		public bool Connected { get; }

		public WorkingStatistics GetWorkingStatistics(int id)
		{
			Id = id;
			return _getWorkingStatistics[id];
		}

		public bool VeryfiedCalledWithPropertyId(int id)
		{
			return Id == id;
		}

	}
}
