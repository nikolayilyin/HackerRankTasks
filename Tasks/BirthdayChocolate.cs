using System.Collections.Generic;

namespace Tasks {
	// https://www.hackerrank.com/challenges/the-birthday-bar/problem
	public class BirthdayChocolate {

		// Complete the birthday function below.
		public static int birthday(List<int> s, int d, int m) {
			int ways = 0;

			if (s.Count < m) {
				return ways;
			}

			for (int i = 0; i < s.Count - m + 1; i++) {
				int sum = 0;
				for(int j = 0; j< m; j++) {
					sum += s[i + j];
				}

				if(sum == d) {
					ways++;
				}
			}

			return ways;
		}
	}
}
