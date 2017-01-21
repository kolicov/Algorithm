using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs_AdjacencyLists
{
    public class Node
    {
        List<int> _childrenIndexes = new List<int>();

        public Node()
        {
            // Node without predecessors
        }

        public Node(int[] childrenIndexes)
        {
            foreach(int index in childrenIndexes)
            {
                _childrenIndexes.Add(index);
            }
        }

        public List<int> Children
        {
            get
            {
                return _childrenIndexes;
            }
        }

        public int Index { get; set; }
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


        public void InsertNode(int index, Node node)
        {
            node.Index = index;

            _nodes.Insert(index, node);
        }
    }
}
