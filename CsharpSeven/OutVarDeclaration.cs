using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CsharpSeven
{
	public class OutVarDeclarationTests
	{
		[Fact]
		public void Works_With_Try_Parse()
		{
			/* Setup */
			var guidAsString = Guid.NewGuid().ToString();

			/* Test & Assert */
			if (Guid.TryParse(guidAsString, out var parsed))
			{
				Assert.NotEqual(parsed, Guid.Empty);
			}
			else
			{
				Assert.True(false, "Could not parse Guid");
			}
		}

		[Fact]
		public void Works_With_Discard_Operator()
		{
			/* Setup */
			var guidAsString = Guid.NewGuid().ToString();

			/* Test */
			var isGuid = Guid.TryParse(guidAsString, out _);

			/* Assert */
			Assert.True(isGuid);
		}
	}
}
