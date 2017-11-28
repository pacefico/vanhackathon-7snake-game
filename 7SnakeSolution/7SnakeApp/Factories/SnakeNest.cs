using _7SnakeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7SnakeApp.Factories
{
    public class SnakeNest : Object
    {
        private const int NODEMAX = 7;
        public Dictionary<int, List<SnakeItem>> Snakes { get; set; }
        private List<List<int>> meal;
        private int count;

        private List<SnakeItem> snakesFound;

        public List<SnakeItem> SnakesFound
        {
            get { return snakesFound; }
            set { snakesFound = value; }
        }


        public int SnakeCount
        {
            get { return count; }
        }
        private int MaxWidth
        {
            get { return meal.Count;  }
        }
        private int MaxHeigh
        {
            get { return meal[0].Count; }
        }

        public SnakeNest()
        {
            // instantiate new elements
            Snakes = new Dictionary<int, List<SnakeItem>>();
            count = 0;
        }

        public SnakeNest(ref List<List<int>> meal): this()
        { 
            // receive as parameter array from csv file that will serve to feed our snakes
            this.meal = meal;
        }

        public bool FeedFrom(int i, int j)
        {
            // instantiate a new stack to serve to create incomplete snakes
            Stack<SnakeItem> myStack = new Stack<SnakeItem>();

            // first snake is created
            var snake = new SnakeItem();
            snake.AddNode(new Tuple<int, int>(i, j), meal[i][j]);
            myStack.Push(snake);
            
            int count = 1;
            var found = false;
            while (myStack.Count > 0 && !found)
            {
                // for each snake from stack, a new node is created based on its position
                snake = myStack.Pop();
                if (snake.NodeCount == NODEMAX)
                {
                    // once a snake is completed with 7 nodes, then born
                    // verify if existent snake has same value
                    found = SnakeBirth(snake);
                }
                else
                {
                    // here is the core
                    // for last position on its node is calculated new position
                    // taking into account element adjacents
                    var lastNodeFromSnake = snake.PeekNode();
                    List<Tuple<int, int>> nextPositions = Validator.Position(lastNodeFromSnake, MaxWidth, MaxHeigh);
                    foreach (var pos in nextPositions)
                    {
                        if (Validator.HasMinAdjacents(pos, snake.Nodes, 1, MaxWidth, MaxHeigh))
                        {
                            var newSnake = snake.DeepClone();
                            if (newSnake.CanAdd(pos))
                            {
                                // once element adjacent restriction is satisfied, a new node is added to our snake
                                newSnake.AddNode(pos, meal[pos.Item1][pos.Item2]);
                                myStack.Push(newSnake);
                            }
                        }
                    }
                }
                count++;
            }
            return found;
        }

        public void PrintSnakes()
        {
            foreach (var item in Snakes)
            {
                foreach (var snake in item.Value)
                {
                    Console.WriteLine(snake);
                }
            }
            Console.WriteLine("total: " + SnakeCount);
        }

        private bool SnakeBirth(SnakeItem snake)
        {
            // once 7 nodes is contained in our snake, it birth
            count += 1;
            bool found = false;
            int snakeValue = snake.SnakeValue;
            if (!Snakes.ContainsKey(snakeValue))
            {
                // created a new node into the dictionary if its value does not exist
                List<SnakeItem> snakesSameValue = new List<SnakeItem>() { snake };
                Snakes.Add(snakeValue, snakesSameValue);
            }
            else
            {
                // if the same value were found, a new snake is add to a list of the same value
                foreach (var item in Snakes[snakeValue])
                {
                    if (!snake.Equals(item))
                    {
                        // comparing all snakes with same value, 
                        // found if each node from a snake differs from the other
                        SnakesFound = new List<SnakeItem>();
                        SnakesFound.Add(snake);
                        SnakesFound.Add(item);
                        return true;
                    }
                }
                Snakes[snake.SnakeValue].Add(snake);
            }
            return found;
        }
    }
}
