using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
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
        public Node InitialNode { get; set; }
        public ObjectDFS1(Node initialNode)
        {
            this.InitialNode = initialNode;
        }

        public void Search(string name)
        {
            Queue<Node> queue = new Queue<Node>();
            HashSet<Node> visited = new HashSet<Node>();
            Stack<Node> stack = new Stack<Node>();

            queue.Enqueue(this.InitialNode);

            while(queue.Count > 0)
            {
                Node workingNode=queue.Dequeue();
                if(workingNode.Name== name)
                {
                    return;
                }
                else
                {
                    foreach (var item in workingNode.Nodes)
                    {
                        queue.Enqueue(item);
                    }
                }

            }
        }
    }
}
