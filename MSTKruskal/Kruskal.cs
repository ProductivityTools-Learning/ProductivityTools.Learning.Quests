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
        List<Edge> MST = new List<Edge>();
        public void CalculateMST(List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                priorityQueue.Enquene(edge);
            }

            while (priorityQueue.Length > 0)
            {
                var edge = priorityQueue.Dequene();
                if (QuickUnion.Connected(edge.From, edge.To) == false)
                {
                    MST.Add(edge);
                    QuickUnion.Connect(edge.From, edge.To); 
                }
            }

            Print();
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
