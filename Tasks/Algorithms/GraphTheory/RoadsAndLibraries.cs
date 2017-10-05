using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks.Algorithms.GraphTheory
{
    //https://www.hackerrank.com/challenges/torque-and-development/problem
    public class RoadsAndLibraries
    {
        public List<HashSet<long>> HSs = new List<HashSet<long>>();

        public RoadsAndLibraries()
        {
        }

        public long NumberOfCities { get; set; }

        public long NumberOfRoads { get; set; }

        public long CostToBuildLibrary { get; set; }

        public long CostToRepairRoad { get; set; }

        public void AddCityRoad(long city1, long city2)
        {
            HashSet<long> a1hs = null;
            HashSet<long> a2hs = null;

            foreach (var hs in HSs)
            {
                var isa1 = hs.Contains(city1);
                var isa2 = hs.Contains(city2);
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
                a1hs.Add(city2);
                return;
            }

            if (a2hs != null)
            {
                a2hs.Add(city1);
                return;
            }

            HSs.Add(new HashSet<long> { city1, city2 });
        }

        private long CalcMinCost()
        {
            if (CostToBuildLibrary <= CostToRepairRoad)
                return NumberOfCities * CostToBuildLibrary;

            var arr = HSs.Select(x => (long)x.Count).ToArray();
            var hssum = arr.Sum();

            var unconnectedCitys = NumberOfCities - hssum;

            var money = unconnectedCitys * CostToBuildLibrary;

            for (var i = 0; i < arr.Length; i++)
                money += (arr[i] - 1) * CostToRepairRoad + CostToBuildLibrary;

            return money;
        }


        /// <summary>
        /// minimum cost of making libraries accessible to all the citizens on a new line.
        /// </summary>
        public long MinimumCost { get { return CalcMinCost(); } }
    }
}
