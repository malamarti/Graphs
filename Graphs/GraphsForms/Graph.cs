using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsForms
{
    class Graph
    {
        private int _V;
        private bool _directed;
        LinkedList<int>[] _adj;

        public Graph(int V, bool directed)
        {
            _adj = new LinkedList<int>[V];

            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }

            _V = V;
            _directed = directed;
        }

        public void AddEdge(int v, int w)
        {
            _adj[v].AddLast(w);

            if (!_directed)
            {
                _adj[w].AddLast(v);
            }
        }
        public ICollection<int> BreadthFirstSearch(int startPoint) {
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;
            var result = new List<int>();
            // Create a queue for BFS
            var queue = new Stack<int>();
            visited[startPoint] = true;
            queue.Push(startPoint);
            while (queue.Any()) {
                // Dequeue a vertex from queue and print it
                startPoint = queue.First();
                //Console.Write(startPoint + " ");
                result.Add(queue.Pop());
                LinkedList<int> list = _adj[startPoint];

                foreach (var val in list) {
                    if (!visited[val]) {
                        visited[val] = true;
                        queue.Push(val);
                    }
                }
            }
            return result;
        }

    }
}
