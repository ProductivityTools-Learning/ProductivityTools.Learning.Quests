// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var pawel = new Node() { Name = "Pawel" };
var magda = new Node() { Name = "Magda" };
var gosia = new Node() { Name = "Gosia" };

var marcin = new Node() { Name = "Marcin" };
var kuba = new Node() { Name = "Kuba" };

var e1 = new Edge() { From = pawel, To = magda, Weight = 1 };
var e2 = new Edge() { From = pawel, To = gosia, Weight = 4 };
pawel.Edges.Add(e1);
pawel.Edges.Add(e2);

var e3 = new Edge() { From = magda, To = gosia, Weight = 2 };
magda.Edges.Add(e3);

var e4 = new Edge() { From = gosia, To = kuba, Weight = 2 };
gosia.Edges.Add(e4);
var e5 = new Edge() { From = gosia, To = marcin, Weight = 5 };
gosia.Edges.Add(e5);
var e6 = new Edge() { From = kuba, To = marcin, Weight = 2 };
kuba.Edges.Add(e6);

//position in list or in array define the nodes
List<Node> edges = new List<Node>() { pawel, magda, gosia, kuba, marcin };
var dijskra = new Dijskra();
dijskra.Do(pawel);

//we need to have edges and nodes

class Dijskra
{
    Dictionary<Node, int> DistanceTo = new System.Collections.Generic.Dictionary<Node, int>();
    PriorityQueue priorityQueue = new PriorityQueue();

    public void Do(Node startNode)
    {
        this.priorityQueue.Enquene(startNode);
        this.DistanceTo.Add(startNode, 0);
        while (priorityQueue.Count > 0)
        {
            var nodeToWhichPathIsShortest = this.priorityQueue.Dequene();

            foreach (var edge in nodeToWhichPathIsShortest.Edges)
            {
                Relax(edge);
            }
        }
        Print();
    }

    private void Relax(Edge edge)
    {
        if (priorityQueue.Contains(edge.To) == false)
        {
            priorityQueue.Enquene(edge.To);
        }

        if (DistanceTo.ContainsKey(edge.To) == false)
        {
            DistanceTo[edge.To] = edge.Weight + DistanceTo[edge.From];
        }
        else
        {
            this.priorityQueue.Enquene(edge.To);
            if (DistanceTo[edge.From] + edge.Weight < DistanceTo[edge.To])
            {
                DistanceTo[edge.To] = DistanceTo[edge.From] + edge.Weight;
            }
        }
    }
    private void Print()
    {
        foreach (var item in this.DistanceTo)
        {
            Console.WriteLine(string.Format($"{item.Key.Name} - {item.Value}"));
        }
        Console.ReadLine();
    }
}

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
class Edge
{
    public Node From, To;
    public int Weight;
}

class Node
{
    public Node()
    {
        this.Edges = new List<Edge>();
    }
    public string Name { get; set; }
    public List<Edge> Edges { get; set; }

}