using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Algorithms.GraphTheory
{
    //https://www.hackerrank.com/challenges/synchronous-shopping/problem
    public class SynchronousShopping
    {
        public SynchronousShopping() { }

        public int NumberOfShoppingCentres { get; set; }

        public int NumberOfRoads { get; set; }

        public int NumberOfTypesOfFish { get; set; }

        public void AddShoppingCenter(int numberOfShoppingCenter, params int[] typesOfFish)
        {

        }

        public void AddRoad(int shoppingCenter1, int shoppingCenter2, int cost)
        {

        }

        public long MinimumCost { get { return CalcMinimumCost(); } }

        private long CalcMinimumCost()
        {
            throw new NotImplementedException();
        }
    }
}
