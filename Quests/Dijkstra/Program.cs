// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var e1 = new Edge() { From = "Pawel", To = "Magda", Weigth = 1 };
var e2 = new Edge() { From = "Pawel", To = "Gosia", Weigth = 4 };
var e3 = new Edge() { From = "Magda", To = "Gosia", Weigth = 1 };

//position in list or in array define the nodes
List<Edge> edges = new List<Edge>() { e1, e2, e3 };
var dijskra = new Dijskra(edges);
dijskra.Do(0);

class Edge
{
    public string From, To;
    public int Weigth;
}

class Dijskra
{
    List<Edge> Edges;
    int[] distanceTo;
    PriorityQueue<Edge> priorityQueue = new PriorityQueue<Edge>(x => x.Weigth);
    public Dijskra(List<Edge> edges)
    {
        this.Edges = edges;
        distanceTo = new int[this.Edges.Count];

        for (int i = 0; i < distanceTo.Length; i++)
        {
            distanceTo[i] = int.MaxValue;
        }
    }

    public void Do(int startPosition)
    {
        this.priorityQueue.Enquene(this.Edges[startPosition]);
        while(priorityQueue.Count>0)
        {

        }
    }
}

class PriorityQueue<V>
{
    List<V> List = new List<V>();
    Func<V, int> Selector;

    public PriorityQueue(Func<V,int> selector)
    {
        this.Selector = selector;
    }

    public V Dequene()
    {
        int minValue = int.MaxValue;
        V minElement = List[0];
        foreach (var item in this.List)
        {
            if (this.Selector(item) < minValue)
            {
                minElement=item; ;
                minValue = this.Selector(item);
            }
        }

        this.List.Remove(minElement);
        return minElement;
    }

    public void Enquene(V element)
    {
        this.List.Add(element);
    }

    public int Count
    {
        get
        {
            return this.List.Count();
        }
    }
}