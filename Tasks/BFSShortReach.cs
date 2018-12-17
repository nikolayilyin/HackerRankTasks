using System.Collections.Generic;
using System.Linq;

namespace Tasks {
	// https://www.hackerrank.com/challenges/bfsshortreach/problem
	public class BfsShortReach {
		private class BfsGraph {
			private readonly bool[] closed;
			private readonly int startNode;
			private readonly Graph graph;

			public int[] result { get; }

			public BfsGraph(Graph g, int startNode) {
				graph = g;
				this.startNode = startNode;

				closed = new bool[g.Nodes];
				result = new int[g.Nodes - 1];

				for (int n = 0; n < result.Length; n++) {
					result[n] = -1;
				}
			}

			public void nodeClose(int node) {
				closed[node - 1] = true;
			}

			public bool isNodeClosed(int node) => closed[node - 1];


			public void setPathLen(int node, int pathlen) {
				int number = -1;
				if (node > startNode) {
					number = node - 2;
				}
				else {
					number = node - 1;
				}

				if (result[number] == -1) {
					result[number] = pathlen;
				}
			}
		}

		private class Graph {
			private readonly HashSet<int>[] nodes;
			public int Nodes { get; private set; }

			public Graph(int nodesCount, int[][] edges) {
				Nodes = nodesCount;
				nodes = new HashSet<int>[Nodes];

				for (int n = 0; n < nodesCount; n++) {
					nodes[n] = new HashSet<int>();
				}

				foreach (int[] edge in edges) {
					int from = edge[0];
					int to = edge[1];

					nodes[from - 1].Add(to);
					nodes[to - 1].Add(from);
				}
			}

			public IEnumerable<int> ConnectedNodes(int node) => nodes[node - 1];
		}

		// Complete the bfs function below.
		public static int[] bfs(int n, int m, int[][] edges, int s) {
			Graph graph = new Graph(n, edges);
			BfsGraph bfsG = new BfsGraph(graph, s);

			int pathweight = 6;
			int currentLen = 0;

			Queue<int> queue = new Queue<int>();
			queue.Enqueue(s);

			while (queue.Any()) {
				Queue<int> newqueue = new Queue<int>();
				currentLen += pathweight;

				while (queue.Any()) {
					int current = queue.Dequeue();
					if (bfsG.isNodeClosed(current)) {
						continue;
					}

					bfsG.nodeClose(current);

					foreach (int node in graph.ConnectedNodes(current)) {
						if (bfsG.isNodeClosed(node)) {
							continue;
						}

						newqueue.Enqueue(node);
						bfsG.setPathLen(node, currentLen);
					}
				}

				queue = newqueue;
			}

			return bfsG.result;
		}
	}
}
