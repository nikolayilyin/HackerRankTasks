using System.Linq;
using Tasks;
using Xunit;

namespace XUnitTestProject1 {
	public class BirthdayChocolateTest {
		[Theory]
		[InlineData(new[] { 4 }, 4, 1, 1)]
		[InlineData(new[] { 1, 1, 1, 1, 1, 1 }, 3, 2, 0)]
		[InlineData(new[] { 1, 2, 1, 3, 2 }, 3, 2, 2)]
		public void Test(int[] bar, int day, int month, int expected) {
			int result = BirthdayChocolate.birthday(bar.ToList(), day, month);
			Assert.Equal(expected, result);
		}
	}
}
