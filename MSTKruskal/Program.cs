
using MSTKruskal;

Console.WriteLine("Hello, World!");

var pawel = new Node() { Name = "Pawel" };
var magda = new Node() { Name = "Magda" };
var gosia = new Node() { Name = "Gosia" };

var marcin = new Node() { Name = "Marcin" };
var kuba = new Node() { Name = "Kuba" };

var e1 = new Edge() { From = pawel, To = magda, Weight = 1 };
var e2 = new Edge() { From = pawel, To = gosia, Weight = 4 };

var e3 = new Edge() { From = magda, To = gosia, Weight = 2 };

var e4 = new Edge() { From = gosia, To = kuba, Weight = 2 };
var e5 = new Edge() { From = gosia, To = marcin, Weight = 5 };
var e6 = new Edge() { From = kuba, To = marcin, Weight = 2 };

//position in list or in array define the nodes
List<Edge> edges = new List<Edge>() { e1, e2, e3, e4, e5, e6 };

new MSTKruskal.Kruskal().CalculateMST(edges);
Console.ReadLine();