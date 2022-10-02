// See https://aka.ms/new-console-template for more information
using BFSQuest;

Console.WriteLine("Hello, World!");

ObjectBFS1Worker worker = new ObjectBFS1Worker();
worker.Do();



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
