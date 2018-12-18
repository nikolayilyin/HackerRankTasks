using System;
using System.IO;

namespace Tasks {
	// https://www.hackerrank.com/challenges/breaking-best-and-worst-records/problem
	public class BreakingTheRecords {
		private class Solution {

			// Complete the breakingRecords function below.
			public static int[] breakingRecords(int[] scores) {

				int inc = 0;
				int dec = 0;

				int min = scores[0];
				int max = scores[0];

				for (int i = 1; i < scores.Length; i++) {
					int current = scores[i];
					if (current > max) {
						max = current;
						inc++;
					}
					if (current < min) {
						min = current;
						dec++;
					}
				}

				return new[] { inc, dec };
			}

			private static void Main(string[] args) {
				TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

				int n = Convert.ToInt32(Console.ReadLine());

				int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
				;
				int[] result = breakingRecords(scores);

				textWriter.WriteLine(string.Join(" ", result));

				textWriter.Flush();
				textWriter.Close();
			}
		}
	}
}
