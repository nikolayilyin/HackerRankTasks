using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Algorithms.GraphTheory
{
    // https://www.hackerrank.com/challenges/journey-to-the-moon/problem
    public class JourneyToTheMoon
    {
        public List<HashSet<long>> HSs = new List<HashSet<long>>();

        public JourneyToTheMoon()
        {
        }

        public long N { get; set; }

        public long P { get; set; }

        public long WaysCount { get { return CalcWaysCountSlow(); } }

        public void AddPair(long a1, long a2)
        {
            HashSet<long> a1hs = null;
            HashSet<long> a2hs = null;

            foreach (var hs in HSs)
            {
                var isa1 = hs.Contains(a1);
                var isa2 = hs.Contains(a2);
                if (isa1 && isa2)
                    return;
                if (isa1)
                    a1hs = hs;
                if (isa2)
                    a2hs = hs;

                if (a1hs != null && a2hs != null)
                    break;
            }

            if (a1hs != null && a2hs != null)
            {
                a1hs.UnionWith(a2hs);
                HSs.Remove(a2hs);
                return;
            }

            if (a1hs != null)
            {
                a1hs.Add(a2);
                return;
            }

            if (a2hs != null)
            {
                a2hs.Add(a1);
                return;
            }

            HSs.Add(new HashSet<long> { a1, a2 });
        }

        public void ConsoleReadInput()
        {
            long n, p, a1, a2;

            var nparray = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if (long.TryParse(nparray[0], out n) && long.TryParse(nparray[1], out p))
            {
                N = n;
                P = p;
            }

            for (long i = 0; i < P; i++)
            {
                var pairarray = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (long.TryParse(pairarray[0], out a1) && long.TryParse(pairarray[1], out a2))
                    AddPair(a1, a2);
            }
        }

        private long CalcWaysCountFast()
        {
            var arr = HSs.Select(x => (long)x.Count).ToArray();
            var hssum = arr.Sum();
            var sum = 0L;

            for (long i = 0; i < arr.Length - 1; i++)
                for (long j = i + 1; j < arr.Length; j++)
                    sum += arr[i] * arr[j];

            var missinglength = N - hssum;

            if (arr.Length == 1)
                sum = arr[0] * missinglength;
            else
                sum += sum * missinglength;

            var missingSum = 0L;
            for (long i = 1; i < missinglength; i++)
                missingSum += i;

            return sum + missingSum;
        }

        private long CalcWaysCountSlow()
        {
            var list = HSs.Select(x => (long)x.Count).ToList();
            var hssum = list.Sum();
            var missinglength = N - hssum;

            if (missinglength > 0)
                for (int i = 0; i < missinglength; i++)
                    list.Add(1);

            var arr = list.ToArray();
            var sum = 0L;

            for (long i = 0; i < arr.Length - 1; i++)
                for (long j = i + 1; j < arr.Length; j++)
                    sum += arr[i] * arr[j];

            return sum;
        }
    }
}