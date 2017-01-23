using System;
using System.Collections.Generic;

namespace Algorithms.Graphs_AdjacencyLists
{
    public class Node
    {
        dynamic _value;

        List<int> _predecessorsIndexes = new List<int>();

        public Node()
        {
            // Node without predecessors
        }

        public Node(int[] predecessorsIndexes)
        {
            _predecessorsIndexes.AddRange(predecessorsIndexes);
        }

        public List<int> PredecessorsIndexes
        {
            get
            {
                return _predecessorsIndexes;
            }
        }

        public int Id { get; set; }

        public dynamic Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }

    /// <summary>
    /// Graph implemented with adjacency list.
    /// </summary>
    public class Graph
    {
        List<Node> _nodes = new List<Node>();

        public List<Node> Nodes
        {
            get
            {
                return _nodes;
            }
        }

        /// <summary>
        /// Returns a node at a given position. 
        /// </summary>
        public Node this[int index]
        {
            get
            {
                if (index >= 0 && index < _nodes.Count)
                {
                    return _nodes[index];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns the number of the nodes in the graph.
        /// </summary>
        public int Count
        {
            get
            {
                return _nodes.Count;
            }
        }


        public void InsertNode(int index, int[] predecessors = null, dynamic value = null)
        {
            Node node;

            if (predecessors != null)
            {
                node = new Node(predecessors);
            }
            else
            {
                node = new Node();
            }

            node.Id = index;

            if (value != null)
            {
                node.Value = value;
            }
            else
            {
                node.Value = index;
            }

            _nodes.Insert(index, node);
        }

        /// <summary>
        /// Returns the first node that has the given value.
        /// </summary>
        public int GetNodeIdFromValue(int nodeValue)
        {
            foreach(Node node in Nodes)
            {
                if(node.Value == nodeValue)
                {
                    return node.Id;
                }
            }

            return -1; // not found
        }
    }
}
