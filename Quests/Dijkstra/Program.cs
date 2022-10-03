// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var pawel = new Node() { Name = "Pawel" };
var magda = new Node() { Name = "Magda" };
var gosia = new Node() { Name = "Gosia" };


var e1 = new Edge() { From = pawel, To = magda, Weigth = 1 };
var e2 = new Edge() { From = pawel, To = gosia, Weigth = 4 };
pawel.Edges.Add(e1);
pawel.Edges.Add(e2);

var e3 = new Edge() { From = magda, To = gosia, Weigth = 1 };
magda.Edges.Add(e3);

//position in list or in array define the nodes
List<Node> edges = new List<Node>() { pawel, magda, gosia};
var dijskra = new Dijskra();
dijskra.Do(pawel);

//we need to have edges and nodes
class Edge
{
    public Node From, To;
    public int Weigth;
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

class Dijskra
{
    Dictionary<Node,int> DistanceTo = new System.Collections.Generic.Dictionary<Node, int>();
    PriorityQueue priorityQueue = new PriorityQueue();
    public Dijskra()
    {
       
    }


    public void Do(Node startNode)
    {
        this.priorityQueue.Enquene(startNode);
        this.DistanceTo.Add(startNode, 0);
        while(priorityQueue.Count>0)
        {
            var nodeToWhichPathIsShortest = this.priorityQueue.Dequene();

            foreach (var edge in nodeToWhichPathIsShortest.Edges)
            {
                Relax(edge);
            }
        }
    }

    private void Relax(Edge edge)
    {
        if(DistanceTo.ContainsKey(edge.To)==false)
        {
            DistanceTo[edge.To] = edge.Weigth;
        }
        else
        {
            this.priorityQueue.Enquene(edge.To);
            if (DistanceTo[edge.From]+edge.Weigth < DistanceTo[edge.To])
            {
                DistanceTo[edge.To] = DistanceTo[edge.From] + edge.Weigth;

                if(priorityQueue.Contains(edge.To)==false)
                {
                    priorityQueue.Enquene(edge.To);
                }
            }
        }
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
                if(edge.Weigth<minValue)
                {
                    minElement = node;
                    minValue = edge.Weigth;
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