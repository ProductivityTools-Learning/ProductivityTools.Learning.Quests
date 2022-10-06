// See https://aka.ms/new-console-template for more information
using Dijkstra;


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
new DijkstraBasic().Do(pawel);
new DijkstraLikePrim().Do(pawel);
Console.ReadLine();



//we need to have edges and nodes



