using System.Collections.Generic;
using Tasks.Algorithms.GraphTheory;
using Xunit;

namespace XUnitTestProject.Algorithms.GraphTheory
{
    public class SynchronousShoppingPartsTest1cs
    {
        public SynchronousShoppingPartsTest1cs() { }

        [Fact]
        public void TestWay1()
        {
            var ss = new SynchronousShopping(10, 9, 10);
            int length = 10;
            for (int i = 1; i <= length; i++)
                ss.AddShoppingCenter(i, new[] { "1", i.ToString() });

            ss.AddRoad(1, 2, 10);
            ss.AddRoad(2, 3, 10);
            ss.AddRoad(1, 3, 10);
            ss.AddRoad(3, 4, 10);
            ss.AddRoad(4, 5, 10);
            ss.AddRoad(2, 5, 10);
            ss.AddRoad(4, 7, 10);
            ss.AddRoad(4, 8, 10);
            ss.AddRoad(7, 8, 10);

            var way = ss.FindWay(1, new HashSet<int> { 7, 8 });
            Assert.Empty(way);
        }
    }
}
