using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphCycleTests
    {
        [TestMethod]
        public void GraphAcyclicTest1()
        {
            Graph graph = CreateSimpleGraph1();

            var acyclicChecker = new GraphAcyclicChecker();
            acyclicChecker.SetGraph(graph);

            bool isAcyclic = acyclicChecker.IsAcyclic(graph);

            Assert.AreEqual(isAcyclic, true);
        }

        [TestMethod]
        public void GraphAcyclicTest2()
        {
            Graph graph = CreateSimpleGraph2();

            var acyclicChecker = new GraphAcyclicChecker();
            acyclicChecker.SetGraph(graph);

            bool isAcyclic = acyclicChecker.IsAcyclic(graph);

            Assert.AreEqual(isAcyclic, false);
        }

        [TestMethod]
        public void GraphAcyclicTest3()
        {
            Graph graph = CreateSimpleGraph3();

            var acyclicChecker = new GraphAcyclicChecker();
            acyclicChecker.SetGraph(graph);

            bool isAcyclic = acyclicChecker.IsAcyclic(graph);

            Assert.AreEqual(isAcyclic, true);
        }

        [TestMethod]
        public void GraphAcyclicTest4()
        {
            Graph graph = CreateSimpleGraph4();

            var acyclicChecker = new GraphAcyclicChecker();
            acyclicChecker.SetGraph(graph);

            bool isAcyclic = acyclicChecker.IsAcyclic(graph);

            Assert.AreEqual(isAcyclic, true);
        }

        [TestMethod]
        public void GraphAcyclicTest5()
        {
            Graph graph = CreateSimpleGraph5();

            var acyclicChecker = new GraphAcyclicChecker();
            acyclicChecker.SetGraph(graph);

            bool isAcyclic = acyclicChecker.IsAcyclic(graph);

            Assert.AreEqual(isAcyclic, false);
        }

        private Graph CreateSimpleGraph1()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 1 }, "G");
            graph.InsertNode(1, new int[] { 0 }, "C");

            return graph;
        }

        private Graph CreateSimpleGraph2()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 1, 2 }, "A");
            graph.InsertNode(1, new int[] { 0, 2 }, "D");
            graph.InsertNode(2, new int[] { 0, 1 }, "F");

            return graph;
        }

        private Graph CreateSimpleGraph3()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 3 }, "B");
            graph.InsertNode(1, new int[] { 2, 3 }, "Q");
            graph.InsertNode(2, new int[] { 1 }, "E");
            graph.InsertNode(3, new int[] { 0, 1 }, "P");

            return graph;
        }

        private Graph CreateSimpleGraph4()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 1 }, "K");
            graph.InsertNode(1, new int[] { 0, 2 }, "J");
            graph.InsertNode(2, new int[] { 1, 3, 4 }, "N");
            graph.InsertNode(3, new int[] { 2, 5 }, "M");
            graph.InsertNode(4, new int[] { 2 }, "L");
            graph.InsertNode(5, new int[] { 3 }, "I");

            return graph;
        }

        private Graph CreateSimpleGraph5()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 1 }, "K");
            graph.InsertNode(1, new int[] { 0, 2 }, "J");
            graph.InsertNode(2, new int[] { 1, 3, 4 }, "X");
            graph.InsertNode(3, new int[] { 0, 1 }, "N");
            graph.InsertNode(4, new int[] { 2 }, "M");
            graph.InsertNode(5, new int[] { 3 }, "Y");
            graph.InsertNode(6, new int[] { 1 }, "L");
            graph.InsertNode(7, new int[] { 0, 2 }, "I");
            graph.InsertNode(8, new int[] { 1, 3, 4 }, "A");
            graph.InsertNode(9, new int[] { 0, 1 }, "F");
            graph.InsertNode(10, new int[] { 2 }, "B");
            graph.InsertNode(11, new int[] { 3 }, "Z");
            graph.InsertNode(12, new int[] { 3 }, "E");
            graph.InsertNode(13, new int[] { 3 }, "P");

            return graph;
        }
    }
}
