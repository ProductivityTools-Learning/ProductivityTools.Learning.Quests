using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Learning
{
    public class DijkstraLearn3
    {

        EdgePriorityQueue edgePriorityQueue = new EdgePriorityQueue();
        HashSet<Node> nodesVisited = new HashSet<Node>();

        public void GetPath(Node startNode)
        {
            Visit(startNode);
            while (this.edgePriorityQueue.Count > 0)
            {
                var edge = this.edgePriorityQueue.Dequene();
                Visit(edge.To);
            }
        }

        private void Visit(Node node)
        {
            this.nodesVisited.Add(node);
            foreach (Edge edge in node.Edges)
            {
                if (nodesVisited.Contains(edge.To) == false)
                {
                    this.edgePriorityQueue.Enquene(edge); //??
                }

            }
        }
    }
}
