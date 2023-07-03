using Business.TestDouble.Testable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.TestDoubles
{
	public class DbGateWayStub : IDbGateway
	{
		private WorkingStatistics _ws;

		public WorkingStatistics GetWorkingStatistics(int id)
		{
			return _ws;
		}

		public void SetWorkingStatistics(WorkingStatistics ws)
		{
			_ws = ws;
		}
	}
}
