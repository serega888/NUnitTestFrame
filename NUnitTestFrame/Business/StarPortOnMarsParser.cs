namespace Business
{
	public class StarPortOnMarsParser
	{
		public static int ParsePort(string port)
		{
			if (!port.StartsWith("MARS"))
			{
				throw new FormatException("Port is not in a correct format!");
			}
			else
			{
				const int lastIndexOfPrefix = 4;
				string portNumber = port.Substring(lastIndexOfPrefix);
				return int.Parse(portNumber);
			}
		}
	}
}
