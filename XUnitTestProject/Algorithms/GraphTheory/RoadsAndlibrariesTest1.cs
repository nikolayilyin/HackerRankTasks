using Tasks.Algorithms.GraphTheory;
using Xunit;

namespace XUnitTestProject.Algorithms.GraphTheory
{
    public class RoadsAndLibrariesTest1
    {
        public RoadsAndLibrariesTest1()
        {
            //RoadsAndLibrariesTestData1RawInput.input5.SplitPairs().WritePairsToFile("test5");
            //RoadsAndLibrariesTestData1RawInput.input8.SplitPairs().WritePairsToFile("test8");
            //RoadsAndLibrariesTestData1RawInput.input3.SplitPairs().WritePairsToFile("test3");
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
        public void Test31()
        {
            var inparr = RoadsAndLibrariesTestData1.inputparams1;
            var pairs = RoadsAndLibrariesTestData1.inputpairs1;
            var output = RoadsAndLibrariesTestData1.output1;

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
        public void Test37()
        {
            var inparr = RoadsAndLibrariesTestData1.inputparams7;
            var pairs = RoadsAndLibrariesTestData1.inputpairs7;
            var output = RoadsAndLibrariesTestData1.output7;

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

        [Fact]
        public void Test39()
        {
            var inparr = RoadsAndLibrariesTestData1.inputparams9;
            var pairs = RoadsAndLibrariesTestData1.inputpairs9;
            var output = RoadsAndLibrariesTestData1.output9;

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