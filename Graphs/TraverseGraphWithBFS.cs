using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class TraverseGraphWithBFS
    {
        Graph _graph;
        List<int> _outputNodes;
        List<int> _visitedNodes;


        public void Run()
        {
            var graph = new Graph();

            graph.AddChildNodes(0, new List<int>() { 3, 6 });
            graph.AddChildNodes(1, new List<int>() { 2, 3, 4, 5, 6 });
            graph.AddChildNodes(2, new List<int>() { 1, 4, 5 });
            graph.AddChildNodes(3, new List<int>() { 1, 5 });
            graph.AddChildNodes(4, new List<int>() { 1, 2, 6 });
            graph.AddChildNodes(5, new List<int>() { 1, 2, 3 });
            graph.AddChildNodes(6, new List<int>() { 0, 1, 4 });

            var nodeValues = new string[] { "Ruse", "Sofia", "Pleven", "Varna", "Bourgas", "Stara Zagora", "Plovdiv" };

            TraverseGraphBFS(graph, nodeValues, false);
        }

        /// <summary>
        /// Traverses all the nodes of the graph.
        /// </summary>
        private void TraverseGraphBFS(Graph graph, string[] nodeValues, bool useReqursiveImplementation)
        {
            _graph = graph;
            _outputNodes = new List<int>();
            _visitedNodes = new List<int>();

            if (useReqursiveImplementation)
            {
                _visitedNodes.Add(4);
                _outputNodes.Add(4);

                Console.Write("Start BFS from " + nodeValues[4] + ": ");
                TraverseGraphNodeBFS(4);
            }
            else
            {
                // Iterative implementation
                TraverseGraphBFS(4);
            }

            // Map the node id(s) with the value
            foreach (var n in _outputNodes)
            {
                Console.Write(nodeValues[n] + ", ");
            }

            Console.WriteLine();
        }

        private void TraverseGraphBFS(int node)
        {
            var nodes = new Queue<int>();
            nodes.Enqueue(node);

            int currNode = node;

            while (nodes.Count > 0)
            {
                node = nodes.Dequeue();

                if (!_visitedNodes.Contains(node))
                {
                    _visitedNodes.Add(node);
                    _outputNodes.Add(node);

                    var children = _graph[node];

                    if (children != null)
                    {
                        foreach (var child in children)
                        {
                            nodes.Enqueue(child);
                        }
                    }
                }
            }
        }

        private void TraverseGraphNodeBFS(int node)
        {
            var children = _graph[node];

            if (children == null)
            {
                return;
            }

            var visitedChildred = new bool[children.Count];

            int i = 0;
            foreach (var child in children)
            {
                if (!_visitedNodes.Contains(child))
                {
                    _visitedNodes.Add(child);
                    _outputNodes.Add(child);
                    visitedChildred[i] = false;
                }
                else
                {
                    visitedChildred[i] = true;
                }

                i++;
            }

            i = 0;
            foreach (var child in children)
            {
                if (!visitedChildred[i])
                {
                    _visitedNodes.Add(child);
                    TraverseGraphNodeBFS(child);
                }

                i++;
            }

            if (_visitedNodes.Contains(node))
            {
                return;
            }
        }
    }
}
