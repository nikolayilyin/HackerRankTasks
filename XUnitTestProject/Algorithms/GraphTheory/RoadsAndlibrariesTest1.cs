using Tasks.Algorithms.GraphTheory;
using Xunit;

namespace XUnitTestProject.Algorithms.GraphTheory
{
    public class RoadsAndlibrariesTest1
    {
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
    }
}