using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTPrim.Learning
{
    internal class PrimLearn2
    {
        EdgePriorityQueue EdgePriorityQueue = new EdgePriorityQueue();
        HashSet<Node> VisitedNodes = new HashSet<Node>();
        List<Edge> Mst =new List<Edge>();
        public void CalculatePath(Node startNode)
        {
            VisitNode(startNode);

            while (EdgePriorityQueue.Count > 0)
            {
                var edge = EdgePriorityQueue.Dequene();
                VisitNode(edge.To);
            }
        }

        private void VisitNode(Node node)
        {
            VisitedNodes.Add(node);
            foreach (var edge in node.Edges)
            {
                if (VisitedNodes.Contains(edge.To) == false)
                {
                    this.EdgePriorityQueue.Enquene(edge);
                    this.Mst.Add(edge);
                }


            }
        }
    }
}
