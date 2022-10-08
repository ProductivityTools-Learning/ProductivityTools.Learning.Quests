using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS.Learning
{
    internal class BFSLearning1
    {
        Queue<Node> nodeQueue = new Queue<Node>();
        public void Search(Node node)
        {
            nodeQueue.Enqueue(node);
            while (nodeQueue.Count > 0)
            {
                var currentNode = nodeQueue.Dequeue();
                foreach (var childNode in currentNode.Nodes)
                {
                    nodeQueue.Enqueue(childNode);
                }
            }
        }
    }
}
