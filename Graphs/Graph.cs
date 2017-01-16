using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class GraphNode
    {
    }

    /// <summary>
    /// Graph implemented with adjacency list.
    /// </summary>
    class Graph
    {
        List<List<int>> _graph = new List<List<int>>();

        public List<int> this[int index]
        {
            get
            {
                if (index >= 0 && index < _graph.Count)
                {
                    return _graph[index];
                }
                else
                {
                    return null;
                }
            }
        }

        public int Count
        {
            get
            {
                return _graph.Count;
            }
        }

        public void AddChildNodes(int parent, List<int> children)
        {
            _graph.Insert(parent, children);
        }
    }
}
