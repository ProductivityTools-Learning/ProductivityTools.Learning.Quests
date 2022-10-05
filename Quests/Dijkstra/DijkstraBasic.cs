using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    internal class DijkstraBasic
    {
        Dictionary<Node, int> DistanceTo = new System.Collections.Generic.Dictionary<Node, int>();
        NodePriorityQueue nodePriorityQueue = new NodePriorityQueue();

        public void Do(Node startNode)
        {
            this.nodePriorityQueue.Enquene(startNode);
            this.DistanceTo.Add(startNode, 0);
            while (nodePriorityQueue.Count > 0)
            {
                var nodeToWhichPathIsShortest = this.nodePriorityQueue.Dequene();

                foreach (var edge in nodeToWhichPathIsShortest.Edges)
                {
                    Relax(edge);
                }
            }
            Print();
        }

        private void Relax(Edge edge)
        {
            if (nodePriorityQueue.Contains(edge.To) == false)
            {
                nodePriorityQueue.Enquene(edge.To);
            }

            if (DistanceTo.ContainsKey(edge.To) == false)
            {
                DistanceTo[edge.To] = edge.Weight + DistanceTo[edge.From];
            }
            else
            {
                this.nodePriorityQueue.Enquene(edge.To);
                if (DistanceTo[edge.From] + edge.Weight < DistanceTo[edge.To])
                {
                    DistanceTo[edge.To] = DistanceTo[edge.From] + edge.Weight;
                }
            }
        }
        private void Print()
        {
            Console.WriteLine("Dijkstra");
            foreach (var item in this.DistanceTo)
            {
                Console.WriteLine(string.Format($"{item.Key.Name} - {item.Value}"));
            }
        }
    }


}
