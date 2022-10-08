using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTKruskal.Learning
{
    internal class KruskalLearn1
    {
        QuickUnion<Node> QuickUnion = new QuickUnion<Node>();
        EdgePriorityQuene PriorityQuene = new EdgePriorityQuene();
        List<Edge> MST=new List<Edge>();
        public void FindMST(List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                this.PriorityQuene.Enquene(edge);
            }

            while(this.PriorityQuene.Length>0)
            {
                var edge = this.PriorityQuene.Dequene();
                if ( QuickUnion.Connected(edge.From, edge.To) == false)
                {
                    this.MST.Add(edge);
                    QuickUnion.Connect(edge.From, edge.To);
                }
            }
        }
    }
}
