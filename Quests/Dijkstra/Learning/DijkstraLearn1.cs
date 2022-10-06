using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    internal class DijkstraLearn1
    {

        private NodePriorityQueue PriorityQuene=new NodePriorityQueue();
        private Dictionary<Node, int> DistenceTo = new Dictionary<Node, int>();

        public void Do(Node startNode)
        {
            DistenceTo.Add(startNode, 0);
            this.PriorityQuene.Enquene(startNode);

            while (this.PriorityQuene.Count > 0)
            {
                var node = this.PriorityQuene.Dequene();
                foreach(var edge in node.Edges)
                {
                    Relax(edge);
                }
            }
        }

        private void Relax(Edge edge)
        {
            if (DistenceTo.ContainsKey(edge.To)==false)
            {
                DistenceTo.Add(edge.To, edge.Weight);//HERE Is mistake
                this.PriorityQuene.Enquene(edge.To);
            }
            else
            {
                if (DistenceTo[edge.From] + edge.Weight < DistenceTo[edge.To])
                {
                    DistenceTo[edge.To] = DistenceTo[edge.From] + edge.Weight;
                }
            }
        }
    }
}
