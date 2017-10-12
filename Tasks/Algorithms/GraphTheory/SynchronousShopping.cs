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

        public string ToDotGraph()
        {
            var sb = new StringBuilder("graph G {\n");
            for (var i = 1; i <= NumberOfShoppingCentres; i++)
                foreach (var neighbor in _shoppingCentres[i].Neighbors.Where(x => x.Number > i))
                    sb.AppendLine("\t{0} -- {1}  [label=\"{2}\"]".F(i, neighbor.Number, neighbor.Cost));

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
            throw new NotImplementedException();
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

        public List<int> FindWay(int start, HashSet<int> to, out long wayCost)
        {
            wayCost = 0;
            var openVertices = new List<Path> { new Path() { Cost = 0, Number = start } };
            var closedVertices = new HashSet<int>();

            var moveMap = new Path[NumberOfShoppingCentres + 1];

            bool GetOpenVertex(out Path shoppingCenter)
            {
                shoppingCenter = new Path();
                if (openVertices.Count == 0)
                    return false;

                shoppingCenter = openVertices.OrderBy(x => x.Cost).First();
                openVertices.Remove(shoppingCenter);

                return true;
            }

            List<int> RestorePath(int finish, out long wCost)
            {
                wCost = 0;
                var path = new List<int> { finish };

                var backstep = moveMap[finish];
                if (backstep != null)
                    wCost = backstep.Cost;

                var current = finish;
                while (current != start)
                {
                    backstep = moveMap[current];
                    if (backstep == null)
                        break;

                    path.Add(backstep.Number);
                    current = backstep.Number;
                }

                path.Reverse();

                return path;
            }

            moveMap[start] = new Path() { Number = start, Cost = 0 };

            while (GetOpenVertex(out var shoppCenter))
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

                    if (to.Contains(neighbor.Number))
                        return RestorePath(neighbor.Number, out wayCost);

                    openVertices.Add(new Path()
                    {
                        Cost = costToNeighbor,
                        Number = neighbor.Number,
                    });
                }
            }

            return null;
        }
    }
}
