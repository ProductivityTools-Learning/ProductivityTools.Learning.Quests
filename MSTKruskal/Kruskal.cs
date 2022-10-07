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
        List<Edge> edges = new List<Edge>();
        public void CalculateMST(List<Edge> vistedEdges)
        {
            foreach (var edge in vistedEdges)
            {
                priorityQueue.Add(edge);
            }

            while (priorityQueue.Length > 0)
            {
                var edge = priorityQueue.Dequene();
                if (vistedEdges.Count<vistedEdges.Count &&  QuickUnion.Connected(edge.From, edge.To) == false)
                {
                    vistedEdges.Add(edge);    
                    QuickUnion.Connect(edge.From, edge.To); 
                }
            }
        }
    }


}
