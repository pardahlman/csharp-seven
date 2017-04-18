using System;
using Xunit;

namespace CsharpSeven
{
	public class ThrowExceptions
	{
		[Fact]
		public void Works_With_Null_Coalescing_Operator()
		{
			Assert.Throws<Exception>(() =>
			{
				string name = null;
				var theName = name ?? throw new Exception();
			});
		}

		[Fact]
		public void Works_With_Conditional_Operator()
		{
			Assert.Throws<Exception>(() =>
			{
				var id = string.Empty;
				var idAsGuid = Guid.TryParse(id, out var p)
					? p : 
					throw new Exception();
			});
		}

		[Fact]
		public void Works_With_Expression_Bodies()
		{
			void ThrowIt() => throw new Exception();

			Assert.Throws<Exception>(() =>
			{
				ThrowIt();
			});
		}
	}
}
