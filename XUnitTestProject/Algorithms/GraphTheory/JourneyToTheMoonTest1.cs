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
            var jttm = new JourneyToTheMoon();

            var n = 5;
            var p = 3;
            var pairs = new[] {
                new[] { 0, 1 },
                new[] { 2, 3 },
                new[] { 0, 4 }
            };

            jttm.N = n;
            jttm.P = p;

            foreach (var pair in pairs)
                jttm.AddPair(pair[0], pair[1]);

            Assert.Equal(6, jttm.WaysCount);
        }

        [Fact]
        public void Test2()
        {
            var jttm = new JourneyToTheMoon();

            var n = 4;
            var p = 1;
            var pairs = new[] {
                new[] { 0, 2 },
            };

            jttm.N = n;
            jttm.P = p;

            foreach (var pair in pairs)
                jttm.AddPair(pair[0], pair[1]);

            Assert.Equal(5, jttm.WaysCount);
        }

        [Fact]
        public void Test3()
        {
            var jttm = new JourneyToTheMoon();

            var n = 100000;
            var p = 2;

            var pairs = new[] {
                new[] { 1, 2 },
                new[] { 3, 4 },
            };

            jttm.N = n;
            jttm.P = p;

            foreach (var pair in pairs)
                jttm.AddPair(pair[0], pair[1]);

            long result = 4999949998;
            Assert.Equal(result, jttm.WaysCount);
        }

        [Fact]
        public void Test4()
        {
            var jttm = new JourneyToTheMoon();

            var n = 5;
            var p = 2;
            var pairs = new[] {
                new[] { 0, 1 },
                new[] { 2, 3 },
            };

            jttm.N = n;
            jttm.P = p;

            foreach (var pair in pairs)
                jttm.AddPair(pair[0], pair[1]);

            Assert.Equal(8, jttm.WaysCount);
        }

        [Fact]
        public void Test5()
        {
            var jttm = new JourneyToTheMoon();

            var n = 6;
            var p = 2;
            var pairs = new[] {
                new[] { 0, 1 },
                new[] { 2, 3 },
            };

            jttm.N = n;
            jttm.P = p;

            foreach (var pair in pairs)
                jttm.AddPair(pair[0], pair[1]);

            Assert.Equal(13, jttm.WaysCount);
        }

        [Fact]
        public void Test6()
        {
            var jttm = new JourneyToTheMoon();

            var n = 10;
            var p = 7;
            var pairs = new[] {
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

            foreach (var pair in pairs)
                jttm.AddPair(pair[0], pair[1]);

            Assert.Equal(23, jttm.WaysCount);
        }

        [Fact]
        public void Test7()
        {
            var jttm = new JourneyToTheMoon();

            var n = 500;
            var p = 500;
            var pairs = JourneyToTheMoonTestData.input1.SplitPairs();

            jttm.N = n;
            jttm.P = p;

            for (var i = 0; i < pairs.Length; i += 2)
                jttm.AddPair(long.Parse(pairs[i]), long.Parse(pairs[i + 1]));

            Assert.Equal(JourneyToTheMoonTestData.output1, jttm.WaysCount);
        }
    }
}