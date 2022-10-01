using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSQuest
{
    public class ObjectBFS1Worker
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

            var dfs = new ObjectBFS1(pawel);
            var result = dfs.Search("Justyna");
            Assert.IsNotNull(result);


            dfs = new ObjectBFS1(justyna);
            result = dfs.Search("Pawel");
            Assert.IsNotNull(result);

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
    public class ObjectBFS1
    {
        public Node InitialNode { get; set; }
        public ObjectBFS1(Node initialNode)
        {
            this.InitialNode = initialNode;
        }

        public Node Search(string name)
        {
            Queue<Node> queue = new Queue<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            queue.Enqueue(this.InitialNode);

            while (queue.Count > 0)
            {
                Node workingNode = queue.Dequeue();
                Console.WriteLine(workingNode.Name);

                visited.Add(workingNode);

                if (workingNode.Name == name)
                {
                    return workingNode;
                }
                else
                {
                    foreach (var item in workingNode.Nodes)
                    {
                        if (visited.Contains(item) == false)
                        {
                            queue.Enqueue(item);
                        }
                    }
                }

            }
            return null;
        }
    }
}
