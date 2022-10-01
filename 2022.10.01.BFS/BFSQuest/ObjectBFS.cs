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

        private void PrintPath(Dictionary<Node, Node> parents, Node lastElement)
        {
            Console.WriteLine("Path");
            var element = lastElement;
            while (parents.ContainsKey(element))
            {
                Console.WriteLine(element.Name);
                element = parents[element];
            }
            Console.WriteLine("---------");
        }

        public Node Search(string name)
        {
            Queue<Node> queue = new Queue<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            //we need to have reference to parent if we would like to print the path
            Dictionary<Node, Node> ParentPath = new Dictionary<Node, Node>();

            queue.Enqueue(this.InitialNode);

            while (queue.Count > 0)
            {
                Node workingNode = queue.Dequeue();
                Console.WriteLine(workingNode.Name);

                visited.Add(workingNode);

                if (workingNode.Name == name)
                {
                    PrintPath(ParentPath, workingNode);
                    return workingNode;
                }
                else
                {
                    foreach (var item in workingNode.Nodes)
                    {
                        if (visited.Contains(item) == false)
                        {
                            visited.Add(item);
                            ParentPath.Add(item, workingNode);
                            queue.Enqueue(item);
                        }
                    }
                }

            }
            return null;
        }
    }
}
