using System;
using System.Reflection;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Xunit;

namespace CsharpSeven
{
	public class ValueTask
	{
		[Fact]
		public async Task Can_Be_Awaited()
		{
			ValueTask<int> GetIntAsync()
			{
				return new ValueTask<int>(1);
			}

			/* Setup */
			/* Test */
			var i = await GetIntAsync();

			/* Assert */
			Assert.Equal(i, 1);
		}

		[Fact]
		public async Task Can_Be_Async()
		{
			async ValueTask<int> GetIntAsync()
			{
				return 1;
			}

			/* Setup */
			/* Test */
			var i = await GetIntAsync();

			/* Assert */
			Assert.Equal(i, 1);
		}

		public void Is_Faster_Than_Task()
		{
			var result = BenchmarkRunner.Run<ValueTaskBenchmark>();
			var taskTime = result.Reports[0].ResultStatistics.Mean;
			var valueTaskTime = result.Reports[1].ResultStatistics.Mean;
			Assert.True(taskTime < valueTaskTime);
		}
	}

	public class ValueTaskBenchmark
	{
		[Benchmark]
		public async Task<int> TestTask()
		{
			await Task.Delay(TimeSpan.FromTicks(1));
			return 10;
		}

		[Benchmark]
		public async ValueTask<int> TestValueTask()
		{
			await Task.Delay(TimeSpan.FromTicks(1));
			return 10;
		}
	}
}
