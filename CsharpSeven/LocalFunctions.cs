using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CsharpSeven
{
	public class LocalFunctionsTests
	{
		[Fact]
		public void Works_For_String()
		{
			/* Setup */
			const string name = "World";

			/* Test */
			var greeting = LocalFunctions.Greet(name);

			/* Assert */
			Assert.Equal(greeting, "Hello, World!");
		}

		[Fact]
		public async Task Work_With_Async_Await()
		{
			/* Setup */
			const string name = "World";

			/* Test */
			var greeting = await LocalFunctions.GreetAsync(name);

			/* Assert */
			Assert.Equal(greeting, "Hello, World!");
		}

		[Fact]
		public void Work_With_Yielded_Enumerable()
		{
			/* Setup */
			const string name = "World";

			/* Test */
			var greeting = LocalFunctions.YieldGreet(name);

			/* Assert */
			Assert.Equal(greeting, "Hello, World!");
		}

		[Fact]
		public void Works_With_Nested_Methods()
		{
			/* Setup */
			const string name = "World";

			/* Test */
			var greeting = LocalFunctions.GreetNested(name);

			/* Assert */
			Assert.Equal(greeting, "Hello, World!");
		}

		[Fact]
		public void Works_With_Complex_Nested_Method()
		{
			/* Setup */
			const string name = "World";

			/* Test */
			var greeting = LocalFunctions.GreetComplexNested(name);

			/* Assert */
			Assert.Equal(greeting, "Hello, World!");
		}
	}

	public class LocalFunctions
	{
		public const string HelloTemplate = "Hello, {0}!";

		public static string Greet(string name)
		{
			var template = GetTemplate();
			return string.Format(template, name);

			string GetTemplate()
			{
				return HelloTemplate;
			}
		}

		public static string GreetNested(string name)
		{
			var template = GetTemplate();
			return string.Format(template, name);

			string GetTemplate()
			{
				return ReallyGetItNow();

				string ReallyGetItNow()
				{
					return ReallyReallyReallyGetIt();

					string ReallyReallyReallyGetIt()
					{
						return HelloTemplate;
					}
				}
			}
		}

		public static string GreetComplexNested(string name)
		{
			var template = GetTemplate();
			return string.Format(template, name);

			string GetTemplate()
			{
				return GetFromSecondLevelLocal();

				string GetFromSecondLevelLocal()
				{
					// Call to local method of outer scoop
					return GetFromFirstLevelLocal();
				}
			}

			string GetFromFirstLevelLocal()
			{
				return HelloTemplate;
			}
		}

		public static async Task<string> GreetAsync(string name)
		{
			var template = await GetTemplateAsync();
			return string.Format(template, name);

			Task<string> GetTemplateAsync()
			{
				return Task.FromResult(HelloTemplate);
			}
		}

		public static string YieldGreet(string name)
		{
			var template = string.Concat(GetTemplateCharacters());
			return string.Format(template, name);

			IEnumerable<char> GetTemplateCharacters()
			{
				foreach (var character in HelloTemplate)
				{
					yield return character;
				}
			}
		}
	}
}
