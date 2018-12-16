using Tasks.Algorithms.GraphTheory;
using Xunit;

namespace XUnitTestProject.Algorithms.GraphTheory
{
	public class JourneyToTheMoonTest1
	{
		public JourneyToTheMoonTest1()
		{
		}

		[Fact]
		public void Test1()
		{
			JourneyToTheMoon jttm = new JourneyToTheMoon();

			int n = 5;
			int p = 3;
			int[][] pairs = new[] {
				new[] { 0, 1 },
				new[] { 2, 3 },
				new[] { 0, 4 }
			};

			jttm.N = n;
			jttm.P = p;

			foreach (int[] pair in pairs) {
				jttm.AddPair(pair[0], pair[1]);
			}

			Assert.Equal(6, jttm.WaysCount);
		}

		[Fact]
		public void Test2()
		{
			JourneyToTheMoon jttm = new JourneyToTheMoon();

			int n = 4;
			int p = 1;
			int[][] pairs = new[] {
				new[] { 0, 2 },
			};

			jttm.N = n;
			jttm.P = p;

			foreach (int[] pair in pairs) {
				jttm.AddPair(pair[0], pair[1]);
			}

			Assert.Equal(5, jttm.WaysCount);
		}

		[Fact]
		public void Test3()
		{
			JourneyToTheMoon jttm = new JourneyToTheMoon();

			int n = 100000;
			int p = 2;

			int[][] pairs = new[] {
				new[] { 1, 2 },
				new[] { 3, 4 },
			};

			jttm.N = n;
			jttm.P = p;

			foreach (int[] pair in pairs) {
				jttm.AddPair(pair[0], pair[1]);
			}

			long result = 4999949998;
			Assert.Equal(result, jttm.WaysCount);
		}

		[Fact]
		public void Test4()
		{
			JourneyToTheMoon jttm = new JourneyToTheMoon();

			int n = 5;
			int p = 2;
			int[][] pairs = new[] {
				new[] { 0, 1 },
				new[] { 2, 3 },
			};

			jttm.N = n;
			jttm.P = p;

			foreach (int[] pair in pairs) {
				jttm.AddPair(pair[0], pair[1]);
			}

			Assert.Equal(8, jttm.WaysCount);
		}

		[Fact]
		public void Test5()
		{
			JourneyToTheMoon jttm = new JourneyToTheMoon();

			int n = 6;
			int p = 2;
			int[][] pairs = new[] {
				new[] { 0, 1 },
				new[] { 2, 3 },
			};

			jttm.N = n;
			jttm.P = p;

			foreach (int[] pair in pairs) {
				jttm.AddPair(pair[0], pair[1]);
			}

			Assert.Equal(13, jttm.WaysCount);
		}

		[Fact]
		public void Test6()
		{
			JourneyToTheMoon jttm = new JourneyToTheMoon();

			int n = 10;
			int p = 7;
			int[][] pairs = new[] {
				new[] {0, 2},
				new[] {1, 8},
				new[] {1, 4},
				new[] {2, 8},
				new[] {2, 6},
				new[] {3, 5},
				new[] {6, 9},
			};

			jttm.N = n;
			jttm.P = p;

			foreach (int[] pair in pairs) {
				jttm.AddPair(pair[0], pair[1]);
			}

			Assert.Equal(23, jttm.WaysCount);
		}

		[Fact]
		public void Test7()
		{
			JourneyToTheMoon jttm = new JourneyToTheMoon();

			int n = 500;
			int p = 500;
			string[] pairs = JourneyToTheMoonTestData.input1.SplitPairs();

			jttm.N = n;
			jttm.P = p;

			for (int i = 0; i < pairs.Length; i += 2) {
				jttm.AddPair(long.Parse(pairs[i]), long.Parse(pairs[i + 1]));
			}

			Assert.Equal(JourneyToTheMoonTestData.output1, jttm.WaysCount);
		}
	}
}