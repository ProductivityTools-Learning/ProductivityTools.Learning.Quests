using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Learning
{
    internal class DijkstraLearn7
    {
        EdgePriorityQueue edgePriorityQueue = new EdgePriorityQueue();
        Dictionary<Node, int> PathTo = new Dictionary<Node, int>();
        public void FindPath(Node startNode)
        {
            Visit(startNode);
            while (edgePriorityQueue.Count > 0)
            {
                var edge = edgePriorityQueue.Dequene();
                Visit(edge.To);
            }
        }

        private void Visit(Node node)
        {
            foreach (var edge in node.Edges)
            {
                this.edgePriorityQueue.Enquene(edge);

                if (PathTo.ContainsKey(edge.To) == false || PathTo[edge.To] > PathTo[edge.From] + edge.Weight)
                {
                    PathTo[edge.To] = PathTo[edge.From] + edge.Weight;
                }
            }

        }
    }
}
