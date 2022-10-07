using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTPrim.Learning
{
    internal class PrimLearn3
    {
        EdgePriorityQueue EdgePriorityQueue = new EdgePriorityQueue();
        HashSet<Node> VisitedNodes = new HashSet<Node>();
        List<Edge> MST=new List<Edge>();

        public void FindMST(Node startNode)
        {
            Visit(startNode);
            while (EdgePriorityQueue.Count > 0)
            {
                var edge = EdgePriorityQueue.Dequene();
                if (VisitedNodes.Contains(edge.To) == false)
                {
                    this.MST.Add(edge);
                }
                Visit(edge.To);
            }

            Print();

        }

        private void Visit(Node node)
        {
            VisitedNodes.Add(node);
            foreach (var edge in node.Edges)
            {
                if (VisitedNodes.Contains(edge.To) == false)
                {
                    this.EdgePriorityQueue.Enquene(edge);
                }
            }
        }

        private void Print()
        {
            Console.WriteLine("Prim2");
            foreach (var item in MST)
            {
                Console.WriteLine($"{item.From.Name} - {item.To.Name}");
            }
        }
    }
}
