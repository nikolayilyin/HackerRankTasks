using System;
using System.Collections.Generic;
using System.Text;
using Tasks;
using Xunit;

namespace XUnitTestProject1 {
	public class RemoveSymbolsToGetAlphabeticalOrderTest {

		[Theory]
		[InlineData("banana", 3)]
		[InlineData("banananabba", 11 - 6)]
		[InlineData("zzbabaabcde", 11 - 7)]
		public void Test(string sentence, int result) {
			runTest(sentence, result);
		}

		private void runTest(string sentence, int expected) {
			int result = RemoveSymbolsToGetAlphabeticalOrder.process(sentence);
			Assert.Equal(expected, result);
		}
	}
}
