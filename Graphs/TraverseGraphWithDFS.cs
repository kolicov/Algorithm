using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class TraverseGraphWithDFS
    {
        Graph _graph;
        List<int> _outputNodes;
        List<int> _visitedNodes;

        public void Run()
        {
            var graph = new Graph();

            graph.AddChildNodes(0, new List<int>() { });
            graph.AddChildNodes(1, new List<int>() { 2, 3, 4, 5, 6 });
            graph.AddChildNodes(2, new List<int>() { 1, 4, 5 });
            graph.AddChildNodes(3, new List<int>() { 1, 5 });
            graph.AddChildNodes(4, new List<int>() { 1, 2, 6 });
            graph.AddChildNodes(5, new List<int>() { 1, 2, 3 });
            graph.AddChildNodes(6, new List<int>() { 1, 4 });

            var nodeValues = new string[] { "Ruse", "Sofia", "Pleven", "Varna", "Bourgas", "Stara Zagora", "Plovdiv" };

            TraverseGraphDFS(graph, nodeValues);
        }

        private void TraverseGraphDFS(Graph graph, string[] nodeValues)
        {
            _graph = graph;
            _outputNodes = new List<int>();
            _visitedNodes = new List<int>();

            // Start from 0 node children
            for (int node = 0; node < _graph.Count; node++)
            {
                Console.Write("Start DFS from " + nodeValues[node] + ": ");
                TraverseGraphNodeDFS(node);

                // Map the node id(s) with the value
                foreach (var n in _outputNodes)
                {
                    Console.Write(nodeValues[n] + ", ");
                }

                _outputNodes.Clear();
                Console.WriteLine();
            }
        }

        private void TraverseGraphNodeDFS(int node)
        {
            if (_visitedNodes.Contains(node))
            {
                return;
            }

            _visitedNodes.Add(node);
            _outputNodes.Add(node);

            var children = _graph[node];

            if (children == null)
            {
                return;
            }

            foreach (var child in children)
            {
                TraverseGraphNodeDFS(child);
            }
        }
    }
}
