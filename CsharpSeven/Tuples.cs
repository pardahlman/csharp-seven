using System;
using Xunit;

namespace CsharpSeven
{
	public class Tuples
	{
		[Fact]
		public void Works_For_Simple_Tuple()
		{
			(int Added, int Multiplied) Calculate(int first, int second)
			{
				return (first + second, first * second);
			}

			/* Setup */
			const int four = 4;
			const int five = 5;

			/* Test */
			var result = Calculate(four, five);

			/* Assert */
			Assert.Equal(result.Added, 9);
			Assert.Equal(result.Multiplied, 20);
		}

		[Fact]
		public void Works_As_Class_Member()
		{
			/* Setup */
			var person = new Person
			{
				FirstName = "Darth",
				LastName = "Vader"
			};

			/* Test */
			var fullName = person.FullName;

			/* Assert */
			Assert.Equal(fullName.First, person.FirstName);
			Assert.Equal(fullName.Last, person.LastName);
		}

		[Fact]
		public void Should_Survive_Type_Casting()
		{
			/* Setup */
			var person = new Person
			{
				FirstName = "Darth",
				LastName = "Vader"
			};
			var tupple = person.FullName;
			var tuppleAsObj = tupple as object;

			/* Test */
			var backAgain = (ValueTuple<string, string>)tuppleAsObj;

			/* Assert */
			Assert.Equal(backAgain.Item1, person.FirstName);
			Assert.Equal(backAgain.Item2, person.LastName);
		}

		[Fact]
		public void Works_With_Generic_Arguments()
		{
			(T1 FirstArgument, T2 SecondArgument) Create<T1, T2>(T1 t1, T2 t2)
			{
				return (t1, t2);
			}

			/* Setup */
			const int one = 1;
			const string hello = "hello";
			/* Test */
			var tupple = Create(one, hello);

			/* Assert */
			Assert.Equal(tupple.FirstArgument, one);
			Assert.Equal(tupple.SecondArgument, hello);
		}

		[Fact]
		public void Can_Be_Deconstructed()
		{
			(int Added, int Multiplied) Calculate(int first, int second)
			{
				return (first + second, first * second);
			}

			/* Setup */
			const int four = 4;
			const int five = 5;

			/* Test */
			(var added, var multipled) = Calculate(four, five);

			/* Assert */
			Assert.Equal(added, 9);
			Assert.Equal(multipled, 20);
		}


		[Fact]
		public void Can_Deconstruct_Objects()
		{
			/* Setup */
			var person = new Person
			{
				FirstName = "Obi-Wan",
				LastName = "Kenobi"
			};

			/* Test */
			(var first, var last) = person;

			/* Assert */
			Assert.Equal(first, person.FirstName);
			Assert.Equal(last, person.LastName);
		}

		[Fact]
		public void Can_Deconstruct_Objects_With_Discard_Operator()
		{
			/* Setup */
			var person = new Person
			{
				FirstName = "Obi-Wan",
				LastName = "Kenobi"
			};

			/* Test */
			(var first, _) = person;

			/* Assert */
			Assert.Equal(first, person.FirstName);
		}

		[Fact]
		public void Can_Deconstruct_From_Extension_Method()
		{
			/* Setup */
			var xmas = new DateTime(2017, 12, 24);

			/* Test */
			(var year, var month, var day) = xmas;

			/* Assert */
			Assert.Equal(xmas.Year, year);
			Assert.Equal(xmas.Month, month);
			Assert.Equal(xmas.Day, day);
		}
	}

	internal class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public (string First, string Last) FullName => (FirstName, LastName);

		public void Deconstruct(out string firstName, out string lastName)
		{
			firstName = FirstName;
			lastName = LastName;
		}
	}

	internal static class DateTimeDeconstructExtension
	{
		public static void Deconstruct(this DateTime datetime, out int year, out int month, out int day)
		{
			year = datetime.Year;
			month = datetime.Month;
			day = datetime.Day;
		}

		public static void Deconstruct(this DateTime datetime, out int year, out int month)
		{
			year = datetime.Year;
			month = datetime.Month;
		}
	}
}
