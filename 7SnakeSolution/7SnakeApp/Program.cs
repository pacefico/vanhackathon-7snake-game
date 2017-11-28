using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using _7SnakeApp.Model;
using _7SnakeApp.Factories;

namespace _7SnakeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // arg[1] matrix size
            // arg[2] csv file path 
            if (args.Length > 2)
            {
                string path = args[2];
                if (File.Exists(path))
                {
                    int size;
                    if (Int32.TryParse(args[1], out size))
                    {
                        //Initiate 7 snake game
                        Operation.Search2Snakes(size, path);
                    }
                    else
                    {
                        Console.WriteLine("Size has not been defined correctly: " + size);
                    }
                }
                else
                {
                    Console.WriteLine("File not found: " + path);
                }
            }
            else
            {
                // if only size were defined, self generate a new random matrix
                if (args.Length > 0)
                {
                    // if only size were defined, self generate a new random matrix
                    int size;
                    if (Int32.TryParse(args[1], out size))
                    {
                        string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                        string name = String.Format("Data\\{0}x{0}.csv", size);
                        var filePath = Path.Combine(path, name);

                        Operation.GenerateFiles(size, filePath);
                        Operation.Search2Snakes(size, filePath);
                    }
                }
                else
                {
                    //if nothing is defined use local data csv file
                    int size = 10;
                    string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                    string name = String.Format("Data\\{0}x{0}.csv", size);
                    var filePath = Path.Combine(path, name);
                    Operation.Search2Snakes(size, filePath);
                }
            }
        }
    }
}
