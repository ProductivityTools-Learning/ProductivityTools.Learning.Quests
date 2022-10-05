using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class PriorityQueue
    {
        List<Node> List = new List<Node>();

        public PriorityQueue()
        {
        }

        public Node Dequene()
        {
            int minValue = int.MaxValue;
            Node minElement = List[0];

            foreach (var node in this.List)
            {
                foreach (var edge in node.Edges)
                {
                    if (edge.Weight < minValue)
                    {
                        minElement = node;
                        minValue = edge.Weight;
                    }
                }
            }

            this.List.Remove(minElement);
            return minElement;
        }

        public void Enquene(Node element)
        {
            this.List.Add(element);
        }

        public bool Contains(Node element)
        {
            return this.List.Contains(element);
        }

        public int Count
        {
            get
            {
                return this.List.Count();
            }
        }

    }
}
