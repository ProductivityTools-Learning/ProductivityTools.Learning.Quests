Console.WriteLine("Hello, World!");

var pawel = new Node() { Name = "Pawel" };
var magda = new Node() { Name = "Magda" };
var gosia = new Node() { Name = "Gosia" };

var marcin = new Node() { Name = "Marcin" };
var kuba = new Node() { Name = "Kuba" };

var e1 = new Edge() { From = pawel, To = magda, Weigth = 1 };
var e2 = new Edge() { From = pawel, To = gosia, Weigth = 4 };
pawel.Edges.Add(e1);
pawel.Edges.Add(e2);

var e3 = new Edge() { From = magda, To = gosia, Weigth = 2 };
magda.Edges.Add(e3);

var e4 = new Edge() { From = gosia, To = kuba, Weigth = 2 };
gosia.Edges.Add(e4);
var e5 = new Edge() { From = gosia, To = marcin, Weigth = 5 };
gosia.Edges.Add(e5);
var e6 = new Edge() { From = kuba, To = marcin, Weigth = 2 };
kuba.Edges.Add(e6);

//position in list or in array define the nodes
List<Node> edges = new List<Node>() { pawel, magda, gosia, kuba, marcin };

new Prim().Do(pawel);
Console.ReadLine();

class Prim
{
    PriorityQueue EdgePriorityQuene = new PriorityQueue();
    private HashSet<Node> NodesVisited = new HashSet<Node>();
    List<Edge> MST = new List<Edge>();
    public void Do(Node startNode)
    {
        Visit(startNode);

        while (this.EdgePriorityQuene.Count > 0)
        {
            Edge edge = this.EdgePriorityQuene.Dequene();
            if (this.NodesVisited.Contains(edge.To) == false)
            {
                this.MST.Add(edge);
                Visit(edge.To); 
            }
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
        }
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

public class Edge
{
    public Node From, To;
    public int Weigth { get; set; }
}

public class Node
{
    public string Name { get; set; }
    public List<Edge> Edges = new List<Edge>();
}

public class PriorityQueue
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
            if (result == null || item.Weigth < result.Weigth) { result = item; }
        }
        this.Edges.Remove(result);
        return result;
    }
}
