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

            graph.AddChildNodes(0, new List<int>() { 3, 6});
            graph.AddChildNodes(1, new List<int>() { 2, 3, 4, 5, 6 });
            graph.AddChildNodes(2, new List<int>() { 1, 4, 5 });
            graph.AddChildNodes(3, new List<int>() { 1, 5 });
            graph.AddChildNodes(4, new List<int>() { 1, 2, 6 });
            graph.AddChildNodes(5, new List<int>() { 1, 2, 3 });
            graph.AddChildNodes(6, new List<int>() { 0, 1, 4 });

            var nodeValues = new string[] { "Ruse", "Sofia", "Pleven", "Varna", "Bourgas", "Stara Zagora", "Plovdiv" };

            TraverseGraphBFS(graph, nodeValues);
        }

        private void TraverseGraphBFS(Graph graph, string[] nodeValues)
        {
            _graph = graph;
            _outputNodes = new List<int>();
            _visitedNodes = new List<int>();

            // Start from 0 node children
            //for (int node = 0; node < 2; node++)
            //{
                Console.Write("Start BFS from " + nodeValues[4] + ": ");
                TraverseGraphNodeBFS(4);
                 
                // Map the node id(s) with the value
                foreach (var n in _outputNodes)
                { 
                    Console.Write(nodeValues[n] + ", ");
                }

                _outputNodes.Clear();
                Console.WriteLine();
            //}
        }

        private void TraverseGraphNodeBFS(int node)
        {
            if (_visitedNodes.Contains(node))
            {
                return;
            }

            _visitedNodes.Add();

            var children = _graph[node];

            if (children == null)
            {
                return;
            }

            _outputNodes.AddRange(children);
            _visitedNodes.AddRange(children);

            foreach (var child in children)
            {
                TraverseGraphNodeBFS(child);
            }
        }
    }
}
