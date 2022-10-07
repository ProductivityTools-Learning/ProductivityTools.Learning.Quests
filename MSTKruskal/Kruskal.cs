using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTKruskal
{
    internal class Kruskal
    {
        PriorityQuene priorityQueue = new PriorityQuene();
        QuickUnion<Node> QuickUnion = new QuickUnion<Node>();
        List<Edge> visitedEdges = new List<Edge>();
        public void CalculateMST(List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                priorityQueue.Add(edge);
            }

            while (priorityQueue.Length > 0)
            {
                var edge = priorityQueue.Dequene();
                if (visitedEdges.Count<edges.Count &&  QuickUnion.Connected(edge.From, edge.To) == false)
                {
                    visitedEdges.Add(edge);    
                    QuickUnion.Connect(edge.From, edge.To); 
                }
            }

            Print();
        }

        private void Print()
        {
            Console.WriteLine("Prim2");
            foreach (var item in visitedEdges)
            {
                Console.WriteLine($"{item.From.Name} - {item.To.Name}");
            }
        }
    }


}
