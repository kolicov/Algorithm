using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs_AdjacencyMatrix
{
    /// <summary>
    /// Graph implemented with adjacency matrix.
    /// </summary>
    public class Graph
    {
        bool[,] _matrix;

        public Graph(int matrixSize)
        {
            _matrix = new bool[matrixSize, matrixSize];
        }

        /// <summary>
        /// Returns a node at a given position. 
        /// </summary>
        public List<int> this[int index]
        {
            get
            {
                if (index >= 0 && index < _matrix.Length)
                {
                    var predecessors = new List<int>();

                    for(int i = 0; i < Count; i++)
                    {
                        if(_matrix[index, i]) // If status is "true"
                        {
                            predecessors.Add(i);
                        }
                    }
 
                    return predecessors;
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
                return _matrix.GetLength(0);
            }
        }

        /// <summary>
        /// Inserts a node with a list of predecessors.
        /// </summary>
        public void InsertNode(int index, int[] predecessors = null)
        {
            if (predecessors != null)
            {
                foreach (int predecessor in predecessors)
                {
                    _matrix[index, predecessor] = true;
                }
            }
        }
    }
}
