using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphTraversingTests
    {
        [TestMethod]
        public void TraverseGraphDFSUsingRecursion()
        {
            var graph = CreateSimpleGraph();

            List<int> nodes = (new GraphTraversingWithDFS()).TraverseGraph(graph, 4, true);

            var expectedNodes = new List<int>() { 4, 1, 2, 5, 3, 0, 6 };

            CollectionAssert.AreEqual(nodes, expectedNodes);
        }

        [TestMethod]
        public void TraverseGraphDFSUsingIteration()
        {
            var graph = CreateSimpleGraph();

            List<int> nodes = (new GraphTraversingWithDFS()).TraverseGraph(graph, 4, false);

            var expectedNodes = new List<int>() { 4, 1, 2, 5, 3, 0, 6 };

            CollectionAssert.AreEqual(nodes, expectedNodes);
        }

        [TestMethod]
        public void TraverseGraphBFSUsingRecursion()
        {
            var graph = CreateSimpleGraph();

            List<int> nodes = (new GraphTraversingWithBFS()).TraverseGraph(graph, 4, true);

            var expectedNodes = new List<int>() { 4, 1, 2, 6, 3, 5, 0 };

            CollectionAssert.AreEqual(nodes, expectedNodes);
        }

        [TestMethod]
        public void TraverseGraphBFSUsingIteration()
        {
            var graph = CreateSimpleGraph();

            List<int> nodes = (new GraphTraversingWithBFS()).TraverseGraph(graph, 4, false);

            var expectedNodes = new List<int>() { 4, 1, 2, 6, 3, 5, 0 };

            CollectionAssert.AreEqual(nodes, expectedNodes);
        }

        private Graph CreateSimpleGraph()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 3, 6 });
            graph.InsertNode(1, new int[] { 2, 3, 4, 5, 6 });
            graph.InsertNode(2, new int[] { 1, 4, 5 });
            graph.InsertNode(3, new int[] { 0, 1, 5 });
            graph.InsertNode(4, new int[] { 1, 2, 6 });
            graph.InsertNode(5, new int[] { 1, 2, 3 });
            graph.InsertNode(6, new int[] { 0, 1, 4 });

            return graph;
        }
    }
}
