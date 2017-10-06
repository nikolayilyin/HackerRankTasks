using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks.Algorithms.GraphTheory
{
    //https://www.hackerrank.com/challenges/torque-and-development/problem
    public class RoadsAndLibraries
    {
        private HashSet<int>[] _graph = null;
        private int _cities;

        public RoadsAndLibraries()
        {
        }

        public int NumberOfCities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                _graph = new HashSet<int>[value];
            }
        }

        public int NumberOfRoads { get; set; }

        public long CostToBuildLibrary { get; set; }

        public long CostToRepairRoad { get; set; }

        public void AddCityRoad(int city1, int city2)
        {
            var city1number = city1 - 1;
            var city2number = city2 - 1;

            if (_graph[city1number] == null && _graph[city2number] == null)
            {
                _graph[city1number] = new HashSet<int>() { city1number, city2number };
                _graph[city2number] = _graph[city1number];
            }
            else if (_graph[city1number] == null)
            {
                _graph[city2number].Add(city1number);
                _graph[city1number] = _graph[city2number];
            }
            else if (_graph[city2number] == null)
            {
                _graph[city1number].Add(city2number);
                _graph[city2number] = _graph[city1number];
            }
            else if (_graph[city1number] != _graph[city2number])
            {
                _graph[city1number].UnionWith(_graph[city2number]);
                foreach (var city in _graph[city2number])
                    _graph[city] = _graph[city1number];
            }
        }

        private long CalcMinCost()
        {
            if (CostToBuildLibrary <= CostToRepairRoad)
                return NumberOfCities * CostToBuildLibrary;

            var unconnectedCities = _graph.Where(x => x == null).Count();
            var money = unconnectedCities * CostToBuildLibrary;

            var arr = _graph.Where(x => x != null).Distinct().Select(x => (long)x.Count).ToArray();
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
