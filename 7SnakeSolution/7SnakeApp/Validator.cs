using _7SnakeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7SnakeApp
{
    public class Validator
    {
        private static bool validSum(int i, int max)
        {
            return ((i + 1) >= 0) && ((i + 1) < max);
        }
        private static bool validSub(int i)
        {
            return (i - 1) >= 0;
        }
        private static bool validMax(int i, int max)
        {
            return i <= max;
        }

        public static List<Tuple<int,int>> Position(Tuple<int,int> node, int maxI, int maxJ)
        {
            
            int i = node.Item1;
            int j = node.Item2;

            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            if (validMax(i, maxI) && validSum(j, maxJ))
            {
                list.Add(new Tuple<int, int>(i, j + 1));
            }
            if (validSum(i, maxI) && validMax(j, maxJ))
            {
                list.Add(new Tuple<int, int>(i + 1, j));
            }
            if (validSub(i) && validMax(j, maxJ))
            {
                list.Add(new Tuple<int, int>(i - 1, j));
            }
            
            if (validMax(i, maxI) && validSub(j))
            {
                list.Add(new Tuple<int, int>(i, j - 1));
            }

            return list;
        }

        public static bool HasMinAdjacents(Tuple<int, int> node, List<Tuple<int, int>> nodesExistent, int min, int maxI, int maxJ)
        {
            List<Tuple<int, int>> adjacents = Position(node, maxI, maxJ);

            int count = 0;
            foreach (var item in adjacents)
            {
                foreach (var existent in nodesExistent)
                {
                    if (item.Item1 == existent.Item1 && item.Item2 == existent.Item2)
                    {
                        count += 1;
                    }
                }
            }
            return count <= min;
        }
    }
}
