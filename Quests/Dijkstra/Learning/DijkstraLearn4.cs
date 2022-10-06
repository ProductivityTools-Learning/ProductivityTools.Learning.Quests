using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Learning
{
    internal class DijkstraLearn4
    {
        EdgePriorityQueue EdgePriorityQueue = new EdgePriorityQueue();
        HashSet<Node> Visited = new HashSet<Node>();
        Dictionary<Node, int> PathTo = new Dictionary<Node, int>();

        public void FindPath(Node startNode)
        {
            Visit(startNode);
            PathTo.Add(startNode, 0);
            while (this.EdgePriorityQueue.Count > 0)
            {
                Edge edge = this.EdgePriorityQueue.Dequene();
                if (Visited.Contains(edge.To) == false)
                {
                    Visit(edge.To);
                }
            }
        }

        private void Visit(Node node)
        {
            foreach (Edge edge in node.Edges)
            {
                this.EdgePriorityQueue.Enquene(edge);

                if(PathTo.ContainsKey(edge.To) == false  || PathTo[edge.To]>PathTo[edge.From]+edge.Weight)
                {
                    PathTo[edge.To] = PathTo[edge.From] + edge.Weight;
                }
            }

            
        }

    }
}
