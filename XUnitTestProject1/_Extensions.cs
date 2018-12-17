using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace XUnitTestProject1
{
	public static class _Extensions
	{
		public static string[] SplitPairs(this string str)
		{
			return str.Split(new[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
		}

		public static void WritePairsToFile(this string[] pairs, [CallerMemberName] string methodName = "")
		{
			string filename = methodName + ".txt";

			if (File.Exists(filename)) {
				File.Delete(filename);
			}

			using (FileStream file = File.OpenWrite(filename))
			using (StreamWriter writer = new StreamWriter(file))
			{
				writer.WriteLine("\t\tpublic static int[,] inputp" + methodName + " = {");

				int cntr = 0;

				for (int i = 0; i < pairs.Length; i += 2)
				{
					if (cntr == 0) {
						writer.Write("\t\t\t");
					}

					writer.Write("{" + pairs[i] + ", " + pairs[i + 1] + "}");
					if (cntr++ < 8) {
						writer.Write(", ");
					}
					else
					{
						cntr = 0;
						writer.WriteLine(",");
					}
				}

				writer.WriteLine(" };\r\n\r\n");
			}
		}

		public static int ToInt(this string inputnumber)
		{
			int.TryParse(inputnumber, out int result);
			return result;
		}

		public static IEnumerator<string> ReadLineIEnumerator(this string inputstring)
		{
			string[] input = inputstring.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

			IEnumerable<string> Read()
			{
				foreach (string line in input) {
					yield return line;
				}
			}

			return Read().GetEnumerator();
		}
	}
}
