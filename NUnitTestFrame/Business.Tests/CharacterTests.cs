using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
	[TestFixture]
	public class CharacterTests
	{
		#region String Tests

		[Test]
		public void ShouldSetName()
		{
			const string expected = "Green";
			Character character = new Character(Type.Human, expected);

			Assert.That(character.Name, Is.EqualTo(expected));
			Assert.That(character.Name, Is.Not.Empty);
			Assert.That(character.Name, Contains.Substring("reen"));
		}

		[Test]
		public void ShouldSetNameCaseInsensitive()
		{
			const string expectedUpperCase = "GREEN";
			const string expectedLowerCase = "green";
			Character character = new Character(Type.Human, expectedUpperCase);

			Assert.That(character.Name, Is.EqualTo(expectedLowerCase).IgnoreCase);
		}

		#endregion

		#region Numerical Tests

		[Test]
		public void DefaultHealthIs100()
		{
			Character character = new Character(Type.Human);
			const int expectedHealth = 100;
			
			Assert.That(character.Health, Is.EqualTo(expectedHealth));
			Assert.That(character.Health, Is.Positive);
			//Assert.That(character.Health, Is.Negative);
		}

		[Test]
		public void Human_SpeedIsCorrect()
		{
			Character character = new Character(Type.Human);
			const double expectedSpeed = 1.4;

			Assert.That(character.Speed, Is.EqualTo(expectedSpeed));
		}

		[Test]
		public void Robot_SpeedIsCorrect()
		{
			Character character = new Character(Type.Robot);
			const double expectedSpeed = 1.8;

			Assert.That(character.Speed, Is.EqualTo(expectedSpeed));
		}

		[Test]
		//[Ignore("")]
		public void Human_SpeedIsCorrectWithToLerance()
		{
			Character character = new Character(Type.Human);
			const double expectedSpeed = 0.3 + 1.1;

			//Assert.That(character.Speed, Is.EqualTo(expectedSpeed)); // проблема с плавающими точками
			Assert.That(character.Speed, Is.EqualTo(expectedSpeed).Within(0.5));
			Assert.That(character.Speed, Is.EqualTo(expectedSpeed).Within(1).Percent);
		}

		[Test]
		//[Ignore("")]
		public void RangesEqualsValueOfDates()
		{
			//ranges of DateTimes
			DateTime dateTime = new DateTime(2000, 1, 1); // 366 Days

			//Assert.That(dateTime, Is.EqualTo(new DateTime(2001, 1, 1))); // так ошибка 366 < 365
			Assert.That(dateTime, Is.EqualTo(new DateTime(2004, 1, 1)).Within(TimeSpan.FromDays(1466)));
			//Assert.That(dateTime, Is.EqualTo(new DateTime(2001, 1, 1)).Within(TimeSpan.FromDays(365))); // так ошибка 366 < 365
			Assert.That(dateTime, Is.EqualTo(new DateTime(2001, 1, 1)).Within(TimeSpan.FromDays(366)));
			Assert.That(dateTime, Is.EqualTo(new DateTime(2001, 1, 1)).Within(366).Days);
		}

		#endregion

		#region Nulls and Booleans

		[Test]
		public void DefaultNameIsNull()
		{
			Character character = new Character(Type.Human);

			Assert.That(character.Name, Is.Null);
		}

		[Test]
		public void IsDead_KillCharacter_ReturnsTrue() 
		{
			Character character = new Character(Type.Human);
			character.Damage(500);
			Assert.That(character.IsDead, Is.True);
			Assert.IsTrue(character.IsDead); // old approach
		}

		#endregion

		#region Collections

		[Test]
		public void CollectionTests()
		{
			Character character = new Character(Type.Human);
			character.Weaponry.Add("Blaster");
			character.Weaponry.Add("Laser sword");

			Assert.That(character.Weaponry, Is.All.Not.Empty);
			Assert.That(character.Weaponry, Contains.Item("Laser sword"));
			Assert.That(character.Weaponry, Has.Exactly(2).Length);
			Assert.That(character.Weaponry, Has.Exactly(1).EndsWith("ster"));
			Assert.That(character.Weaponry, Is.Unique);
			Assert.That(character.Weaponry, Is.Ordered);

			Character characterTwo = new Character(Type.Human);
			characterTwo.Weaponry.Add("Blaster");
			characterTwo.Weaponry.Add("Laser sword");

			Assert.That(character.Weaponry, Is.EquivalentTo(characterTwo.Weaponry));
		}

		#endregion

		#region Reference Equality

		[Test]
		public void SameCharacters_AreEqualByReference()
		{
			Character characterOne = new Character(Type.Human);
			Character characterTwo = characterOne;

			Assert.That(characterOne, Is.SameAs(characterTwo));
		}

		#endregion

		#region Types

		[Test]
		public void TestObjectOfCharacterType()
		{
			object character = new Character(Type.Human);

			Assert.That(character, Is.TypeOf<Character>());
		}

		#endregion

		#region Ranges

		[Test]
		public void DefaultCharacterArmorShouldBeGreaterThan50AndLessThan100()
		{
			Character character = new Character(Type.Human);

			Assert.That(character.Armor, Is.GreaterThan(59).And.LessThan(61));
			Assert.That(character.Armor, Is.InRange(59, 61));

			Character characterTwo = new Character(Type.Robot);

			Assert.That(characterTwo.Armor, Is.GreaterThan(99).And.LessThan(101));
		}

		#endregion

		#region Exceptions

		[Test]
		public void Damage_1000_ThrowsArgumentOutOfRange()
		{
			Character character = new Character(Type.Human);

			Assert.Throws<ArgumentOutOfRangeException>(() => character.Damage(1001));
			//Assert.That(() => character.Damage(1001), Throws.TypeOf<ArgumentOutOfRangeException>()); // old approach
		}

		[Test]
		public void Damage_1000_ThrowsArgumentOutOfRange_BadWay()
		{
			Character character = new Character(Type.Human);

			Assert.Throws<ArgumentOutOfRangeException>(() => character.Damage(1001));
		}

		#endregion
	}
}
