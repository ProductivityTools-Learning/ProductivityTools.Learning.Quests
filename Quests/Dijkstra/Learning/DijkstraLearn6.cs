using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Learning
{
    internal class DijkstraLearn6
    {
        EdgePriorityQueue EdgePriorityQueue = new EdgePriorityQueue();
        HashSet<Node> VisitedNodes = new HashSet<Node>();
        Dictionary<Node, int> PathTo = new Dictionary<Node, int>();
        public void CalculatePath(Node startNode)
        {
            VisitNode(startNode);
            PathTo.Add(startNode, 0);
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
                }

                if (PathTo.ContainsKey(node) == false)
                {
                    PathTo.Add(node, PathTo[edge.From] + edge.Weight);
                }
                else if (PathTo[node] > PathTo[edge.From] + edge.Weight)
                {
                    PathTo[node] = PathTo[edge.From] + edge.Weight;
                }

            }
        }
    }
}
