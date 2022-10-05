using Dijkstra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    internal class DijkstraLikePrim
    {
        EdgePriorityQueue EdgePriorityQuene = new EdgePriorityQueue();
        private HashSet<Node> NodesVisited = new HashSet<Node>();
        List<Edge> MST = new List<Edge>();
        Dictionary<Node, int> DistanceTo = new System.Collections.Generic.Dictionary<Node, int>();

        public void Do(Node startNode)
        {
            this.DistanceTo.Add(startNode, 0);
            Visit(startNode);
            while (this.EdgePriorityQuene.Count > 0)
            {
                Edge edge = this.EdgePriorityQuene.Dequene();
                Visit(edge.To);
            }
            Print();
        }

        public void Visit(Node node)
        {
            this.NodesVisited.Add(node);
            
            foreach (var edge in node.Edges)
            {
                if (NodesVisited.Contains(edge.To) == false)
                {
                    this.EdgePriorityQuene.Enquene(edge);
                }

                if (DistanceTo.ContainsKey(edge.To) == false)
                {
                    DistanceTo[edge.To] = edge.Weight + DistanceTo[edge.From];
                }
                else
                {
                    this.EdgePriorityQuene.Enquene(edge);
                    if (DistanceTo[edge.From] + edge.Weight < DistanceTo[edge.To])
                    {
                        DistanceTo[edge.To] = DistanceTo[edge.From] + edge.Weight;
                    }
                }
            }
        }
        private void Print()
        {
            Console.WriteLine("DijkstraLikePrim");
            foreach (var item in this.DistanceTo)
            {
                Console.WriteLine(string.Format($"{item.Key.Name} - {item.Value}"));
            }
        }
    }
}
public class EdgePriorityQueue
{
    List<Edge> Edges = new List<Edge>();

    public int Count
    {
        get
        {
            return this.Edges.Count;
        }
    }
    public void Enquene(Edge edge)
    {
        this.Edges.Add(edge);
    }

    public Edge Dequene()
    {
        Edge result = null;
        foreach (var item in this.Edges)
        {
            if (result == null || item.Weight < result.Weight) { result = item; }
        }
        this.Edges.Remove(result);
        return result;
    }
}