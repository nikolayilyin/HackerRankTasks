using System;

namespace Tasks {
	/// <summary>
	/// Minimum symbols to remove to get a alphabetically sorted sentence
	/// </summary>
	public class RemoveSymbolsToGetAlphabeticalOrder {
		public static void Run() {
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
			Random rnd = new Random();

			void runfor(string sentence) {
				Console.WriteLine("with " + sentence.Length + " length sentence");

				sw.Restart();
				int result = process(sentence);
				sw.Stop();

				Console.WriteLine("result: " + result + " for " + sw.ElapsedMilliseconds + " ms");
			}

			string getsentence(int len) {
				string s = "";
				for (int i = 0; i < len; i++) {
					s += (char)(rnd.Next('a', 'z' + 1));
				}
				return s;
			}

			runfor("banana"); // expected 3
			runfor("banananabba"); // expected 5
			runfor("zzbabaabcde"); // expected 4

			runfor(getsentence(1000));
			runfor(getsentence(1000));
			runfor(getsentence(10000));
			runfor(getsentence(100000));
			runfor(getsentence(100000));
			runfor(getsentence(100000));
		}

		private class SentenceDescriptor {
			public int Length { get; set; } = 0;
			public char Character { get; }

			public SentenceDescriptor(char character) {
				Character = character;
			}

			public SentenceDescriptor Prev;

			public SentenceDescriptor Next;

			//private string predecessor;
			//private int predecessorLen;

			public void SetPredecessor(SentenceDescriptor descriptor) {
				Length = descriptor.Length + 1;
				//predecessor = $"{descriptor.predecessor}[{descriptor.Character}:{descriptor.Length - descriptor.predecessorLen}]";
				//predecessorLen = descriptor.Length;
			}

			//public override string ToString() => $"{Length}: {predecessor}[{Character}:{Length - predecessorLen}]";
		}

		private class SentenceProcessorArrayBased {
			private readonly SentenceDescriptor[] sentenses = new SentenceDescriptor[26];
			private readonly int delta = 'a';

			public SentenceProcessorArrayBased() {
				for (int i = 0; i < sentenses.Length; i++) {
					sentenses[i] = new SentenceDescriptor((char)(i + delta));
				}
			}

			public void ProcessCharacter(char character) {
				SentenceDescriptor max = getMax(character);
				if (max?.Character == character) {
					max.Length++;
				}
				else {
					SentenceDescriptor current = sentenses[character - delta];
					current.SetPredecessor(max);
				}
			}

			private SentenceDescriptor getMax(char beginning) {
				int adress = beginning - delta;
				SentenceDescriptor max = sentenses[adress];
				for (int i = adress; i >= 0; i--) {
					if (sentenses[i].Length > max.Length) {
						max = sentenses[i];
					}
				}

				//System.Console.WriteLine($"max for '{beginning}' -> {max?.ToString() ?? "empty"}");
				return max;
			}

			public int GetMaxSentenceLen() => getMax('z')?.Length ?? 0;
		}

		public static int process(string sentence) {
			var processor = new SentenceProcessorArrayBased();

			foreach (char character in sentence) {
				processor.ProcessCharacter(character);
			}

			int maxlen = processor.GetMaxSentenceLen();
			return sentence.Length - maxlen;
		}
	}
}
