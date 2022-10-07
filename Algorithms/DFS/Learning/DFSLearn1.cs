using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS.Learning
{
    internal class DFSLearn1
    {
        public void TraverseGraph(Node root, string word)
        {
            Stack<Node> path = new Stack<Node>();
            Traverse(root, word, path);
        }

        private bool Traverse(Node parentNode, string word, Stack<Node> path)
        {
            path.Push(parentNode);
            if (parentNode.Name == word)
            {
                return true;
            }

            
            foreach (var childNode in parentNode.Nodes)
            {
                return Traverse(childNode, word, path);
            }
            path.Pop();
            return false;
        }
    }
}
