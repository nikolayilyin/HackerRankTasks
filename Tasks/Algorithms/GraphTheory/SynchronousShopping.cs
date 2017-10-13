using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks.Algorithms.GraphTheory
{
    //https://www.hackerrank.com/challenges/synchronous-shopping/problem
    public class SynchronousShopping
    {
        public SynchronousShopping(int numberOfShoppingCentres, int numberOfRoads, int numberOfTypesOfFish)
        {
            NumberOfShoppingCentres = numberOfShoppingCentres;
            NumberOfTypesOfFish = numberOfTypesOfFish;
            NumberOfRoads = numberOfRoads;
        }

        /// <summary>
        /// http://dreampuf.github.io/GraphvizOnline/
        /// http://graphs.grevian.org/example
        /// </summary>
        /// <returns></returns>
        public string ToDotGraph()
        {
            var sb = new StringBuilder("graph G {\n");
            for (var i = 1; i <= NumberOfShoppingCentres; i++)
                foreach (var neighbor in _shoppingCentres[i].Neighbors.Where(x => x.Number > i))
                {
                    var shc1 = _shoppingCentres[i];
                    var shc2 = _shoppingCentres[neighbor.Number];
                    var shc1str = "{0}f{1}".F(i, string.Join("", shc1.TypesOfFish));
                    var shc2str = "{0}f{1}".F(neighbor.Number, string.Join("", shc2.TypesOfFish));

                    sb.AppendLine("\tc{0} -- c{1}  [label=\"{2}\"]".F(shc1str, shc2str, neighbor.Cost));
                }

            sb.AppendLine("}");
            return sb.ToString();
        }

        private int _nSC = 0;
        private ShoppingCenter[] _shoppingCentres; // some sort of graph

        public int NumberOfShoppingCentres
        {
            get { return _nSC; }
            set
            {
                _nSC = value;
                _shoppingCentres = new ShoppingCenter[value + 1];
            }
        }

        public int NumberOfRoads { get; set; }

        public int NumberOfTypesOfFish { get; set; }

        public void AddShoppingCenter(int numberOfShoppingCenter, string[] shoppingCenter)
        {
            var sc = numberOfShoppingCenter;
            _shoppingCentres[sc] = new ShoppingCenter();

            for (var i = 1; i < shoppingCenter.Length; i++)
                _shoppingCentres[sc].TypesOfFish.Add(Int32.Parse(shoppingCenter[i]));
        }

        public void AddRoad(int shoppingCenter1, int shoppingCenter2, int cost)
        {
            var sc1 = shoppingCenter1;
            var sc2 = shoppingCenter2;

            if (_shoppingCentres[sc1] == null)
                _shoppingCentres[sc1] = new ShoppingCenter();
            if (_shoppingCentres[sc2] == null)
                _shoppingCentres[sc2] = new ShoppingCenter();

            _shoppingCentres[sc1].Neighbors.Add(new Path() { Number = sc2, Cost = cost });
            _shoppingCentres[sc2].Neighbors.Add(new Path() { Number = sc1, Cost = cost });
        }

        public long MinimumCost { get { return CalcMinimumCost(); } }

        private long CalcMinimumCost()
        {
            var ways = FindTwoLongestWayToFish();

            //while (max2.FishTypes.Union(max2.FishTypes).Count() != NumberOfTypesOfFish)
            //{
            var missedTypesOfFish = new HashSet<int>();
            for (int i = 1; i < NumberOfTypesOfFish; i++)
            {
                if (ways[0].FishTypes.Contains(i))
                    continue;
                if (ways[1].FishTypes.Contains(i))
                    continue;

                missedTypesOfFish.Add(i);
            }
            //}

            return Math.Max(ways[0].Cost, ways[1].Cost);
        }

        private Way[] FindTwoLongestWayToFish()
        {
            var twoways = new Way[2];

            var ways = new Way[NumberOfTypesOfFish + 1];
            var finishsc = NumberOfShoppingCentres;

            for (int i = 1; i <= NumberOfTypesOfFish; i++)
            {
                var way = FindWayToFish(1, new HashSet<int>() { i });
                if (way == null)
                    continue;

                var lastsc = way.Path.LastOrDefault();
                if (lastsc != finishsc)
                {
                    var secway = FindWayToSC(lastsc, finishsc);
                    if (secway != null)
                        way.UnionWith(secway);
                }

                ways[i] = way;
            }

            var uniqueWays = new List<Way>();
            for (int i = 1; i <= NumberOfTypesOfFish; i++)
            {
                if (ways[i] == null)
                    continue;

                var alreadyExist = uniqueWays.FindIndex(x => ways[i].FishTypes.SetEquals(x.FishTypes));
                if (alreadyExist >= 0)
                {
                    if (uniqueWays[alreadyExist].Cost > ways[i].Cost)
                        uniqueWays[alreadyExist] = ways[i];
                    continue;
                }

                uniqueWays.Add(ways[i]);
            }

            if (uniqueWays.Count == 0)
                return twoways;

            twoways[0] = uniqueWays[0];
            twoways[1] = uniqueWays[0];

            if (uniqueWays.Count == 1)
                return twoways;

            twoways[1] = uniqueWays[1];

            Way.Swap(twoways[0], twoways[1]);

            for (int i = 2; i < uniqueWays.Count; i++)
            {
                if (twoways[1].Cost < uniqueWays[i].Cost)
                    twoways[1] = uniqueWays[i];

                Way.Swap(twoways[0], twoways[1]);
            }

            return twoways;
        }

        class ShoppingCenter
        {
            public HashSet<int> TypesOfFish = new HashSet<int>();

            public List<Path> Neighbors = new List<Path>();

            public override string ToString()
            {
                return string.Format("fish: {0}, N: {1}", TypesOfFish.Count, Neighbors.Count);
            }
        }

        class Path
        {
            public int Number;

            public int Cost;

            public override string ToString()
            {
                return string.Format("N: {0} cost: {1}", Number, Cost);
            }
        }

        public class Way
        {
            public List<int> Path = new List<int>();
            public long Cost = 0L;
            public HashSet<int> FishTypes = new HashSet<int>();

            public void UnionWith(Way w)
            {
                var path = w.Path;
                path.RemoveAt(0);
                Path.AddRange(path);

                Cost += w.Cost;

                FishTypes.UnionWith(w.FishTypes);
            }

            public static void Swap(Way max1, Way max2)
            {
                if (max1.Cost >= max2.Cost)
                    return;

                var buf = max1;
                max1 = max2;
                max2 = buf;

            }

            public override string ToString()
            {
                return string.Format("C: {0} FT: {1} P: {2}", Cost, FishTypes.Count, Path.Count);
            }
        }

        public Way FindWayToFish(int start, HashSet<int> fishTypes)
        {
            return FindWay(start, fishTypes, 0);
        }

        public Way FindWayToSC(int start, int shoppingCenter)
        {
            return FindWay(start, null, shoppingCenter);
        }

        private Way FindWay(int start, HashSet<int> fishTypes, int finishShoppingCenter)
        {
            Func<Path, bool> _isItFinish = (finish) => false;
            if (fishTypes != null)
                _isItFinish = (finish) => _shoppingCentres[finish.Number].TypesOfFish.Intersect(fishTypes).Any();
            else
                _isItFinish = (finish) => finish.Number == finishShoppingCenter;

            var openVertices = new List<Path> { new Path() { Cost = 0, Number = start } };

            Func<Path> GetOpenVertex = () =>
            {
                if (openVertices.Count == 0)
                    return null;

                var shoppingCenter = openVertices.OrderBy(x => x.Cost).First();
                openVertices.Remove(shoppingCenter);

                return shoppingCenter;
            };

            var moveMap = new Path[NumberOfShoppingCentres + 1];

            Func<int, Way> RestorePath = (finish) =>
            {
                var way = new Way();
                way.FishTypes.UnionWith(_shoppingCentres[finish].TypesOfFish);
                way.Path.Add(finish);

                var backstep = moveMap[finish];
                if (backstep != null)
                    way.Cost = backstep.Cost;

                var current = finish;
                while (current != start)
                {
                    backstep = moveMap[current];
                    if (backstep == null)
                        break;

                    var shopcenternumber = backstep.Number;
                    way.FishTypes.UnionWith(_shoppingCentres[shopcenternumber].TypesOfFish);
                    way.Path.Add(shopcenternumber);
                    current = shopcenternumber;
                }

                way.Path.Reverse();

                return way;
            };

            var closedVertices = new HashSet<int>();
            moveMap[start] = new Path() { Number = start, Cost = 0 };

            var shoppCenter = GetOpenVertex();

            if (_isItFinish(shoppCenter))
                return RestorePath(shoppCenter.Number);

            while (shoppCenter != null)
            {
                var neighbors = _shoppingCentres[shoppCenter.Number].Neighbors;
                closedVertices.Add(shoppCenter.Number);

                foreach (var neighbor in neighbors.OrderBy(x => x.Cost))
                {
                    if (closedVertices.Contains(neighbor.Number))
                        continue;

                    var costToNeighbor = shoppCenter.Cost + neighbor.Cost;

                    var old = moveMap[neighbor.Number];
                    if (old == null || old.Cost > costToNeighbor)
                        moveMap[neighbor.Number] = new Path()
                        {
                            Cost = costToNeighbor,
                            Number = shoppCenter.Number,
                        };

                    if (_isItFinish(neighbor))
                        return RestorePath(neighbor.Number);

                    openVertices.Add(new Path()
                    {
                        Cost = costToNeighbor,
                        Number = neighbor.Number,
                    });
                }

                shoppCenter = GetOpenVertex();
            }

            return null;
        }
    }
}
