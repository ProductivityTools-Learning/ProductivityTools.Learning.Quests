using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTPrim
{
    internal class PrimLearn1
    {
        PriorityQueue edgePriorityQuene=new PriorityQueue();
        HashSet<Node> NodesVisited=new HashSet<Node>();
        HashSet<Edge> MST = new HashSet<Edge>();
        public void Do(Node initialNode)
        {
            Visit(initialNode);
            while (this.edgePriorityQuene.Count > 0)
            {
                var edge = edgePriorityQuene.Dequene();
                if(NodesVisited.Contains(edge.To)==false)
                {
                    this.MST.Add(edge);
                    Visit(edge.To);
                }
            }
        }

        private void Visit(Node to)
        {
            this.NodesVisited.Add(to);
            foreach(Edge edge in to.Edges)
            {
                if(NodesVisited.Contains(edge.To)==false)
                {
                    this.edgePriorityQuene.Enquene(edge);
                }
            }
        }
    }
}
