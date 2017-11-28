using _7SnakeApp.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7SnakeApp
{
    class Operation
    {
        public static void GenerateFiles(int size, string path)
        {
            //Generarate new csv files based on size, with random numbers between 1-256
            FileHelper.GenerateNewCSV(size, path);
        }

        public static void Search2Snakes(int size, string path)
        {
            // Retrieve data from csv file converting into array sizexsize
            List<List<int>> arr = FileHelper.GetArrayFromCSV(size, path);

            var nest = new SnakeNest(ref arr);
            var found = false;
            var i = 0;
            var j = 0;

            //iterate through each array element 
            while (!found && i < size)
            {
                while (!found && j < size)
                {
                    // start to feed a snake nest from each element
                    found = nest.FeedFrom(i, j);
                    j++;
                }
                i++;
            }
            if (found)
            {
                // once found first 2 snakes with same value print
                foreach(var snake in nest.SnakesFound)
                {
                    Console.WriteLine(snake);
                }
            }
            Console.WriteLine("Snakes: " + nest.SnakeCount);
        }
    }
}
