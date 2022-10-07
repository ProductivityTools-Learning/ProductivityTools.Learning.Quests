using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTKruskal
{
    internal class QuickUnion<T> where T : struct
    {
        Dictionary<T, T> array;

        public QuickUnion()
        {
            this.array = new Dictionary<T, T>();
        }

        private T GetParent(T node)
        {
            while (this.array[node].Equals(node))
            {
                return GetParent(this.array[node]);
            }
            return node;
        }

        public bool Connected(T node1, T node2)
        {
            var node1Parent=GetParent(node1);
            var node2Parent=GetParent(node2);
            return node1Parent.Equals(node2Parent);
        }

        public void Connect(T node1, T node2)
        {
            this.array[node1] = this.array[node2];
        }
    }
}
