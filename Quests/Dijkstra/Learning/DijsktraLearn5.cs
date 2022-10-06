using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Learning
{
    internal class DijsktraLearn5
    {
        EdgePriorityQueue edgePriorityQueue = new EdgePriorityQueue();
        HashSet<Node> Visted=new HashSet<Node>();

        public void FindPath()
        {
            while(this.edgePriorityQueue.Count > 0)
            {
                var edge = this.edgePriorityQueue.Dequene();
                Visit(edge.To);
            }
        }

        private void Visit(Node to)
        {
            foreach (var edge in to.Edges)
            {
                if (Visted.Contains(edge.To)==false)
                {
                    this.edgePriorityQueue.Enquene(edge);
                }
            }
        }
    }
}
