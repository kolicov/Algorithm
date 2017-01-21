using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyMatrix;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphSorterTests
    {
        private Graph CreateSimpleGraph()
        {
            var graph = new Graph(6);

            graph.InsertNode(0, new int[] { 3, 5 });
            graph.InsertNode(1, new int[] { 2 });
            graph.InsertNode(2);
            graph.InsertNode(3, new int[] { 5 });
            graph.InsertNode(4, new int[] { 0, 1 });
            graph.InsertNode(5, new int[] { 1, 2 });

            return graph;
        }

        [TestMethod]
        public void TopologicalSourceRemovalSort()
        {
            Graph graph = CreateSimpleGraph();

            var sorter = new TopologicalSourceRemovalSort();

            List<int> nodes = sorter.Sort(graph);

            var expectedNodes = new List<int>() { 4, 0, 3, 5, 1, 2 };

            CollectionAssert.AreEqual(nodes, expectedNodes);
        }

        [TestMethod]
        public void TopologicalDFSSort()
        {
            Graph graph = CreateSimpleGraph();

            var sorter = new TopologicalDFSSort();

            List<int> nodes = sorter.Sort(graph);

            var expectedNodes = new List<int>() { 4, 0, 3, 5, 1, 2 };

            CollectionAssert.AreEqual(nodes, expectedNodes);
        }
    }
}
