using System;
using System.Collections.Generic;
using System.Text;
using Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class RoadsAndLibrariesTest1
    {
        public RoadsAndLibrariesTest1()
        {

        }

        [Fact]
        public void Test1()
        {
			RoadsAndLibraries ral = new RoadsAndLibraries
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
			RoadsAndLibraries ral = new RoadsAndLibraries
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
			IEnumerator<string> enumerator = RoadsAndLibrariesRawTestData1.input.ReadLineIEnumerator();

            string ReadLine()
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }

			StringBuilder sb = new StringBuilder();
			int q = Convert.ToInt32(ReadLine());

            for (int a0 = 0; a0 < q; a0++)
            {
                string[] tokens_n = ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int m = Convert.ToInt32(tokens_n[1]);
                long x = Convert.ToInt64(tokens_n[2]);
                long y = Convert.ToInt64(tokens_n[3]);

				RoadsAndLibraries ral = new RoadsAndLibraries
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

			string[] result = sb.ToString().Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			string[] expected = RoadsAndLibrariesRawTestData1.output.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(expected.Length, result.Length);

            for (int i = 0; i < expected.Length; i++) {
				Assert.Equal(long.Parse(expected[i]), long.Parse(result[i]));
			}
		}

        [Fact]
        public void Test30()
        {
			int[] inparr = RoadsAndLibrariesTestData1.inputparams0;
			int[,] pairs = RoadsAndLibrariesTestData1.inputpairs0;
			long output = RoadsAndLibrariesTestData1.output0;

			RoadsAndLibraries ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (int i = 0; i < pairs.Length / 2; i++) {
				ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);
			}

			Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test32()
        {
			int[] inparr = RoadsAndLibrariesTestData1.inputparams2;
			int[,] pairs = RoadsAndLibrariesTestData1.inputpairs2;
			long output = RoadsAndLibrariesTestData1.output2;

			RoadsAndLibraries ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (int i = 0; i < pairs.Length / 2; i++) {
				ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);
			}

			Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test33()
        {
			int[] inparr = RoadsAndLibrariesTestData1.inputparams3;
			int[,] pairs = RoadsAndLibrariesTestData1.inputpairs3;
			long output = RoadsAndLibrariesTestData1.output3;

			RoadsAndLibraries ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (int i = 0; i < pairs.Length / 2; i++) {
				ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);
			}

			Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test34()
        {
			int[] inparr = RoadsAndLibrariesTestData1.inputparams4;
			int[,] pairs = RoadsAndLibrariesTestData1.inputpairs4;
			long output = RoadsAndLibrariesTestData1.output4;

			RoadsAndLibraries ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (int i = 0; i < pairs.Length / 2; i++) {
				ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);
			}

			Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test35()
        {
			int[] inparr = RoadsAndLibrariesTestData1.inputparams5;
			int[,] pairs = RoadsAndLibrariesTestData1.inputpairs5;
			long output = RoadsAndLibrariesTestData1.output5;

			RoadsAndLibraries ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (int i = 0; i < pairs.Length / 2; i++) {
				ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);
			}

			Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test36()
        {
			int[] inparr = RoadsAndLibrariesTestData1.inputparams6;
			int[,] pairs = RoadsAndLibrariesTestData1.inputpairs6;
			long output = RoadsAndLibrariesTestData1.output6;

			RoadsAndLibraries ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (int i = 0; i < pairs.Length / 2; i++) {
				ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);
			}

			Assert.Equal(output, ral.MinimumCost);
        }

        [Fact]
        public void Test38()
        {
			int[] inparr = RoadsAndLibrariesTestData1.inputparams8;
			int[,] pairs = RoadsAndLibrariesTestData1.inputpairs8;
			long output = RoadsAndLibrariesTestData1.output8;

			RoadsAndLibraries ral = new RoadsAndLibraries
            {
                NumberOfCities = inparr[0],
                NumberOfRoads = inparr[1],
                CostToBuildLibrary = inparr[2],
                CostToRepairRoad = inparr[3]
            };

            for (int i = 0; i < pairs.Length / 2; i++) {
				ral.AddCityRoad(pairs[i, 0], pairs[i, 1]);
			}

			Assert.Equal(output, ral.MinimumCost);
        }
    }
}