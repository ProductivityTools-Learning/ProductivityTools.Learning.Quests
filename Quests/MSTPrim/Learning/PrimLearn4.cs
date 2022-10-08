using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTPrim.Learning
{
    internal class PrimLearn4
    {
        EdgePriorityQueue EdgePriorityQuene = new EdgePriorityQueue();
        List<Edge> MST = new List<Edge>();
        HashSet<Node> Visted = new HashSet<Node>();

        public void FindMST(Node startNode)
        {
            Visit(startNode);
            while (this.EdgePriorityQuene.Count > 0)
            {
                Edge currentEdge = this.EdgePriorityQuene.Dequene();
                if (this.Visted.Contains(currentEdge.To)==false)
                {
                    Visit(currentEdge.To);
                    this.MST.Add(currentEdge);
                }
            }
        }

        private void Visit(Node node)
        {
            this.Visted.Add(node);
            foreach (var edge in node.Edges)
            {
                this.EdgePriorityQuene.Enquene(edge);

                if(edge.To)
            }
        }
    }
}
