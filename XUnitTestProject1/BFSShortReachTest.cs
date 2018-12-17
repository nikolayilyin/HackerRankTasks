using System;
using Xunit;
using Tasks;
using System.IO;
using System.Linq;

namespace XUnitTestProject1 {
	public class BFSShortReachTest {
		[Fact]
		void Test() {
			checkBFS(BFSShortReachTestData.testcaseMY0, BFSShortReachTestData.testcaseMY0answer);
			checkBFS(BFSShortReachTestData.testcase0, BFSShortReachTestData.testcase0answer);
			checkBFS(BFSShortReachTestData.testcase1, BFSShortReachTestData.testcase1answer);
			checkBFS(BFSShortReachTestData.testcase2, BFSShortReachTestData.testcase2answer);
		}

		void checkBFS(string testdata, string expectedoutput) {
			StringReader datareader = new StringReader(testdata);
			StringReader resultreader = new StringReader(expectedoutput);

			string readDataLine() => datareader.ReadLine();
			string readResultLine() => resultreader.ReadLine();

			int q = Convert.ToInt32(readDataLine());

			for (int qItr = 0; qItr < q; qItr++) {
				string[] nm = readDataLine().Split(' ');

				int n = Convert.ToInt32(nm[0]);
				int m = Convert.ToInt32(nm[1]);

				int[][] edges = new int[m][];

				for (int i = 0; i < m; i++) {
					edges[i] = readDataLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
				}

				int s = Convert.ToInt32(readDataLine());

				string expected = readResultLine();
				string result = string.Join(" ", BfsShortReach.bfs(n, m, edges, s));

				Assert.Equal(expected, result);
			}
		}

	}
}
