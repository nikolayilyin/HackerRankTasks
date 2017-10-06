using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Algorithms.GraphTheory;
using Xunit;

namespace XUnitTestProject.Algorithms.GraphTheory
{
    public class RoadsAndLibrariesTest1
    {
        public RoadsAndLibrariesTest1()
        {

        }

        [Fact]
        public void Test1()
        {
            var ral = new RoadsAndLibraries
            {
                NumberOfCities = 3,
                NumberOfRoads = 3,
                CostToBuildLibrary = 2,
                CostToRepairRoad = 1
            };

            ral.AddCityRoad(1, 2);
            ral.AddCityRoad(3, 1);
            ral.AddCityRoad(2, 3);

            Assert.Equal(4, ral.MinimumCost);
        }

        [Fact]
        public void Test2()
        {
            var ral = new RoadsAndLibraries
            {
                NumberOfCities = 6,
                NumberOfRoads = 6,
                CostToBuildLibrary = 2,
                CostToRepairRoad = 5
            };

            ral.AddCityRoad(1, 3);
            ral.AddCityRoad(3, 4);
            ral.AddCityRoad(2, 4);
            ral.AddCityRoad(1, 2);
            ral.AddCityRoad(2, 3);
            ral.AddCityRoad(5, 6);

            Assert.Equal(12, ral.MinimumCost);
        }

        [Fact]
        public void Test3()
        {
            var input = RoadsAndLibrariesRawTestData1.input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<string> Read()
            {
                foreach (var line in input)
                    yield return line;
            }

            var enumerator = Read().GetEnumerator();

            string ReadLine()
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }

            var sb = new StringBuilder();
            var q = Convert.ToInt32(ReadLine());

            for (int a0 = 0; a0 < q; a0++)
            {
                string[] tokens_n = ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int m = Convert.ToInt32(tokens_n[1]);
                long x = Convert.ToInt64(tokens_n[2]);
                long y = Convert.ToInt64(tokens_n[3]);

                var ral = new RoadsAndLibraries
                {
                    NumberOfCities = n,
                    NumberOfRoads = m,
                    CostToBuildLibrary = x,
                    CostToRepairRoad = y
                };

                for (int a1 = 0; a1 < m; a1++)
                {
                    string[] tokens_city_1 = ReadLine().Split(' ');
                    int city_1 = Convert.ToInt32(tokens_city_1[0]);
                    int city_2 = Convert.ToInt32(tokens_city_1[1]);
                    ral.AddCityRoad(city_1, city_2);
                }

                sb.AppendLine(ral.MinimumCost.ToString());
            }

            var result = sb.ToString().Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var expected = RoadsAndLibrariesRawTestData1.output.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(expected.Length, result.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.Equal(long.Parse(expected[i]), long.Parse(result[i]));
        }

        [Fact]
        public void Test30()
        {
            var inparr = RoadsAndLibrariesTestData1.inputparams0;
            var pairs = RoadsAndLibrariesTestData1.inputpairs0;
            var output = RoadsAndLibrariesTestData1.output0;

            var ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (var i = 0; i < pairs.Length / 2; i++)
                ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);

            Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test32()
        {
            var inparr = RoadsAndLibrariesTestData1.inputparams2;
            var pairs = RoadsAndLibrariesTestData1.inputpairs2;
            var output = RoadsAndLibrariesTestData1.output2;

            var ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (var i = 0; i < pairs.Length / 2; i++)
                ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);

            Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test33()
        {
            var inparr = RoadsAndLibrariesTestData1.inputparams3;
            var pairs = RoadsAndLibrariesTestData1.inputpairs3;
            var output = RoadsAndLibrariesTestData1.output3;

            var ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (var i = 0; i < pairs.Length / 2; i++)
                ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);

            Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test34()
        {
            var inparr = RoadsAndLibrariesTestData1.inputparams4;
            var pairs = RoadsAndLibrariesTestData1.inputpairs4;
            var output = RoadsAndLibrariesTestData1.output4;

            var ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (var i = 0; i < pairs.Length / 2; i++)
                ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);

            Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test35()
        {
            var inparr = RoadsAndLibrariesTestData1.inputparams5;
            var pairs = RoadsAndLibrariesTestData1.inputpairs5;
            var output = RoadsAndLibrariesTestData1.output5;

            var ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (var i = 0; i < pairs.Length / 2; i++)
                ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);

            Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test36()
        {
            var inparr = RoadsAndLibrariesTestData1.inputparams6;
            var pairs = RoadsAndLibrariesTestData1.inputpairs6;
            var output = RoadsAndLibrariesTestData1.output6;

            var ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (var i = 0; i < pairs.Length / 2; i++)
                ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);

            Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test38()
        {
            var inparr = RoadsAndLibrariesTestData1.inputparams8;
            var pairs = RoadsAndLibrariesTestData1.inputpairs8;
            var output = RoadsAndLibrariesTestData1.output8;

            var ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (var i = 0; i < pairs.Length / 2; i++)
                ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);

            Assert.Equal(output, ral.MinimumCost);
        }
    }
}