using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Node
    {
        public Node()
        {
            this.Edges = new List<Edge>();
        }
        public string Name { get; set; }
        public List<Edge> Edges { get; set; }

    }
}
