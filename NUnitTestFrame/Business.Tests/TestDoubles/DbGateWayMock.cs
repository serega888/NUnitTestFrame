using Business.TestDouble.Testable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.TestDoubles
{
	internal class DbGateWayMock : IDbGateway
	{
		private WorkingStatistics _ws;

		public int Id { get; private set; }

		public WorkingStatistics GetWorkingStatistics(int id)
		{
			Id = id;
			return _ws;
		}

		public void SetWorkingStatistics(WorkingStatistics ws)
		{
			_ws = ws;
		}

		public bool VeryfiedCalledWithPropertyId(int id)
		{
			return Id == id;
 		}
	}
}
