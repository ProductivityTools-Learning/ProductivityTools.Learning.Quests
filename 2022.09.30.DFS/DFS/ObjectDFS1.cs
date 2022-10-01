using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    public class ObjectDFS1Worker
    {
        public void Do()
        {
            Node pawel = new Node() { Name = "Pawel" };
            Node magda = new Node() { Name = "Magda" };
            Node marcin = new Node() { Name = "Marcin" };
            Node gosia = new Node() { Name = "Gosia" };
            Node justyna = new Node() { Name = "Justyna" };

            pawel.Nodes.Add(magda);
            pawel.Nodes.Add(gosia);
            magda.Nodes.Add(marcin);
            magda.Nodes.Add(pawel);
            gosia.Nodes.Add(marcin);
            gosia.Nodes.Add(pawel);
            marcin.Nodes.Add(justyna);
            marcin.Nodes.Add(magda);
            marcin.Nodes.Add(gosia);
            justyna.Nodes.Add(marcin);

            var dfs = new ObjectDFS1(pawel);
            var result = dfs.Search(pawel,"Justyna");
            Console.WriteLine(result.Name);
            Assert.IsNotNull(result);


            //dfs = new ObjectDFS1(justyna);
            //result = dfs.Search("Pawel");
            //Assert.IsNotNull(result);

            Console.ReadLine();
        }
    }

    public class Node
    {
        public string Name { get; set; }
        public List<Node> Nodes { get; set; }

        public Node()
        {
            this.Nodes = new List<Node>();
        }
    }

    public class ObjectDFS1
    {
        Node FirstNode;
        HashSet<Node> Visited = new HashSet<Node>();
        public ObjectDFS1(Node firstNode)
        {
            this.FirstNode = firstNode;
        }

        public Node Search(Node node, string lookUpValue)
        {
            Visited.Add(node);
            if (node.Name == lookUpValue)
            {
                return node;
            }
            else
            {
                foreach (var childNode in node.Nodes)
                {
                    if (Visited.Contains(childNode) == false)
                    {
                        return Search(childNode, lookUpValue);
                    }
                }
            }

            throw new Exception("Value not found");
        }
    }
}
