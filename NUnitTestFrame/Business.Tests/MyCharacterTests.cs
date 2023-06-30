using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
	[TestFixture]
	public class MyCharacterTests
	{
		private Character _character;
		[SetUp]
		public void SetUp()
		{
			_character = new Character(Type.Human);
		}

		[TearDown]
		public void TearDown()
		{
			_character.Dispose();
			_character = null;
		}

		[TestCaseSource(typeof(DamageSource))]
		public void Health_Damage_ReturnsCorrectValue(int damage, int expectedHealth)
		{
			_character.Damage(damage);

			Assert.That(_character.Health, Is.EqualTo(expectedHealth));
		}

		public class DamageSource : IEnumerable
		{
			public IEnumerator GetEnumerator()
			{
				yield return new int[] { 100, 45 };
				yield return new int[] { 80, 65 };
			}
		}

	}
}
