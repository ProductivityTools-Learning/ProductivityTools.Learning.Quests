using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS.Learning
{
    internal class DFSLearn2
    {
        private HashSet<Node> visited = new HashSet<Node>();


        public Stack<Node> FindPath(Node node, string query)
        {
            Stack<Node> stack = new Stack<Node>();
            Find(node, query, stack);
            return stack;
        }

        public Node Find(Node node, string query, Stack<Node> stack)
        {
            stack.Push(node);
            if (node.Name == query)
            {
                return node;
            }
            else
            {
                foreach (var childNode in node.Nodes)
                {
                    if (visited.Contains(childNode) == false)
                    {
                        visited.Add(childNode);
                        return Find(childNode, query, stack);
                    }
                }
                stack.Pop();
                return null;
            }
        }
    }
}
