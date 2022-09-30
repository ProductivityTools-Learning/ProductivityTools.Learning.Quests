// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var graph = new UndirectedGraph(7);
graph.AddEdge(0, 1);
graph.AddEdge(0, 6);
graph.AddEdge(1, 2);
graph.AddEdge(1, 3);
graph.AddEdge(3, 4);
graph.AddEdge(2, 6);
graph.AddEdge(6, 5);
graph.AddEdge(4, 5);

var DFS = new DFS(graph);
DFS.Search(5);

class DFS
{
    UndirectedGraph Graph;
    bool[] Marked;
    int[] EdgeTo;
    public DFS(UndirectedGraph graph)
    {
        this.Graph = graph;
        this.Marked = new bool[this.Graph.Edges.Count()];
        this.EdgeTo = new int[this.Graph.Edges.Count()];
    }

    public void Search(int value)
    {
        List<int> firstEdge = this.Graph.Edges[0];
        this.Marked[0] = true;
        this.EdgeTo[0] = 0;
        Step(0, firstEdge, value);
    }

    private void Step(int from, List<int> connections, int value)
    {
        foreach (var connection in connections)
        {
            if (connection == value)
            {
                return;
            }

            if (this.Marked[connection] == false)
            {
                this.Marked[connection] = true;
                this.EdgeTo[connection] = from;
                Step(connection, Graph.Edges[connection], value);
            }
        }
    }
}


class UndirectedGraph
{
    private int V;
    public List<int>[] Edges;

    public UndirectedGraph(int v)
    {
        this.V = v;
        this.Edges = new List<int>[v];
        for (int i = 0; i < V; i++)
        {
            this.Edges[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        Edges[v].Add(w);
        Edges[w].Add(v);
    }
}
