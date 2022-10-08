using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTKruskal.Learning
{
    internal class KruskalLearn2
    {
        private EdgePriorityQuene EdgePriorityQuene = new EdgePriorityQuene();
        QuickUnion<Node> quickUnion=new QuickUnion<Node>();
        public void FindMST()
        {

            

            while(EdgePriorityQuene.Length>0)
            {
                Edge edge = this.EdgePriorityQuene.Dequene();
                if(quickUnion.Connected(edge.To,edge.From)==false)
                {
                    quickUnion.Connect(edge.To,edge.From);
                }
            }
        }
    }
}
