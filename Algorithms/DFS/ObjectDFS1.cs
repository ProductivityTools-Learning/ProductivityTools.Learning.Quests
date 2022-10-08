using DFS.Learning;
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
            gosia.Nodes.Add(pawel);
            marcin.Nodes.Add(justyna);
            marcin.Nodes.Add(magda);
            justyna.Nodes.Add(marcin);

            var dfs = new ObjectDFS1(pawel);
            dfs.Search(pawel,"Gosia");

            var dfs2 = new DFSLearn2();
            var x=dfs2.FindPath(pawel, "Justyna");


            //dfs = new ObjectDFS1(justyna);
            //result = dfs.Search("Pawel");
            //Assert.IsNotNull(result);

            Console.ReadLine();
        }
    }



    public class ObjectDFS1
    {
        Node FirstNode;
        HashSet<Node> Visited = new HashSet<Node>();
        Stack<Node> Path = new Stack<Node>();
        public ObjectDFS1(Node firstNode)
        {
            this.FirstNode = firstNode;
        }

        public Node Search(Node node, string lookUpValue)
        {
            Visited.Add(node);
            Path.Push(node);
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
                        var result=Search(childNode, lookUpValue);
                        //if (result == null)
                        //{
                        //    Path.Pop();
                        //}
                    }
                }
                Path.Pop();
                return null;
            }
        }
    }
}
