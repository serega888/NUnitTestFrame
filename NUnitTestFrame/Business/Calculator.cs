namespace Business
{
	public class Calculator
	{
		private int a, b;
		public Calculator(int a, int b)
		{
			this.a = a;
			this.b = b;
		}
		public int AddNumbers()
		{
			return a + b;
		}
	}
}
