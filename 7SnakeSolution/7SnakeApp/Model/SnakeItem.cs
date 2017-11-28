using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7SnakeApp.Model
{
    [Serializable]
    public class SnakeItem : Object
    {
        private List<Tuple<int,int>> nodes;

        public List<Tuple<int,int>> Nodes
        {
            get { return nodes; }
            private set { nodes = value; }
        }

        private int snakeValue;

        public int SnakeValue
        {
            get { return snakeValue; }
            set { snakeValue = value; }
        }

        public int NodeCount
        {
            get { return nodes.Count; }
        }

        public SnakeItem()
        {
            nodes = new List<Tuple<int, int>>();
            snakeValue = 0;
        }

        public void AddNode(Tuple<int, int> node, int value)
        {
            nodes.Add(node);
            snakeValue += value;
        }

        public bool CanAdd(Tuple<int, int> node)
        {
            return !nodes.Any(m => m.Item1 == node.Item1 && m.Item2 == node.Item2);
        }

        public Tuple<int,int> PeekNode()
        {
            if (nodes.Count > 0)
            {
                return nodes[nodes.Count - 1];
            }
            return null;
        }

        public override bool Equals(object obj)
        {
            foreach(var item in nodes)
            {
                foreach (var itemToCompare in ((SnakeItem)obj).nodes)
                {
                    if (item.Item1 == itemToCompare.Item1 &&
                        item.Item2 == itemToCompare.Item2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in nodes)
            {
                sb.Append(item);
            }
            sb.Append("=" + snakeValue);
            return sb.ToString();
        }
    }
}
