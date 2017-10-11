using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Algorithms.GraphTheory;
using Xunit;

namespace XUnitTestProject.Algorithms.GraphTheory
{
    public class SynchronousShoppingTest1
    {
        public SynchronousShoppingTest1() { }

        public long TestAgainstStringInput(string inputstring)
        {
            var enumerator = inputstring.ReadLineIEnumerator();
            string ReadLine()
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }

            var initarray = ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var ss = new SynchronousShopping(initarray[0].ToInt(), initarray[1].ToInt(), initarray[2].ToInt());

            for (int i = 0; i < ss.NumberOfShoppingCentres; i++)
            {
                var sc = ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                ss.AddShoppingCenter(i + 1, sc);
            }

            for (int i = 0; i < ss.NumberOfRoads; i++)
            {
                var sc = ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                ss.AddRoad(sc[0].ToInt(), sc[1].ToInt(), sc[2].ToInt());
            }

            return ss.MinimumCost;
        }

        [Fact]
        public void Test1()
        {
            var output = TestAgainstStringInput(SynchronousShoppingTestData1.input0);
            Assert.Equal(SynchronousShoppingTestData1.output0, output);
        }
    }
}
