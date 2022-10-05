using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    internal class EdgePriorityQueue
    {
        List<Edge> Edges = new List<Edge>();

        public int Count
        {
            get
            {
                return this.Edges.Count;
            }
        }
        public void Enquene(Edge edge)
        {
            this.Edges.Add(edge);
        }

        public Edge Dequene()
        {
            Edge result = null;
            foreach (var item in this.Edges)
            {
                if (result == null || item.Weight < result.Weight) { result = item; }
            }
            this.Edges.Remove(result);
            return result;
        }
    }
}
