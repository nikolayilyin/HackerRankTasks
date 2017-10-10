using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace XUnitTestProject
{
    public static class Extensions
    {
        public static string[] SplitPairs(this string str)
        {
            return str.Split(new[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void WritePairsToFile(this string[] pairs, [CallerMemberName] string methodName = "")
        {
            var filename = methodName + ".txt";

            if (File.Exists(filename))
                File.Delete(filename);

            using (var file = File.OpenWrite(filename))
            using (var writer = new StreamWriter(file))
            {
                writer.WriteLine("\t\tpublic static int[,] inputp" + methodName + " = {");

                var cntr = 0;

                for (var i = 0; i < pairs.Length; i += 2)
                {
                    if (cntr == 0)
                        writer.Write("\t\t\t");
                    writer.Write("{" + pairs[i] + ", " + pairs[i + 1] + "}");
                    if (cntr++ < 8)
                        writer.Write(", ");
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
            int.TryParse(inputnumber, out var result);
            return result;
        }

        public static IEnumerator<string> ReadLineIEnumerator(this string inputstring)
        {
            var input = inputstring.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<string> Read()
            {
                foreach (var line in input)
                    yield return line;
            }

            return Read().GetEnumerator();
        }
    }
}
