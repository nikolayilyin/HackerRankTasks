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
			IEnumerator<string> enumerator = inputstring.ReadLineIEnumerator();
            string ReadLine()
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }

			string[] initarray = ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
			SynchronousShopping ss = new SynchronousShopping(int.Parse(initarray[0]), int.Parse(initarray[1]), int.Parse(initarray[2]));

            for (int i = 0; i < ss.NumberOfShoppingCentres; i++)
            {
				string[] sc = ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                ss.AddShoppingCenter(i + 1, sc);
            }

            for (int i = 0; i < ss.NumberOfRoads; i++)
            {
				string[] sc = ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                ss.AddRoad(int.Parse(sc[0]), int.Parse(sc[1]), int.Parse(sc[2]));
            }

			string graph = ss.ToDotGraph();

            return ss.MinimumCost;
        }

        [Fact]
        public void Test0()
        {
			long output = TestAgainstStringInput(SynchronousShoppingTestData1.input0);
            Assert.Equal(SynchronousShoppingTestData1.output0, output);
        }

        [Fact]
        public void Test1()
        {
			long output = TestAgainstStringInput(SynchronousShoppingTestData1.input1);
            Assert.Equal(SynchronousShoppingTestData1.output1, output);
        }

        [Fact]
        public void Test5()
        {
			long output = TestAgainstStringInput(SynchronousShoppingTestData1.input5);
            Assert.Equal(SynchronousShoppingTestData1.output5, output);
        }

        [Fact]
        public void Test6()
        {
			long output = TestAgainstStringInput(SynchronousShoppingTestData1.input6);
            Assert.Equal(SynchronousShoppingTestData1.output6, output);
        }

        [Fact]
        public void Test22()
        {
			long output = TestAgainstStringInput(SynchronousShoppingTestData1.input22);
            Assert.Equal(SynchronousShoppingTestData1.output22, output);
        }
    }
}
