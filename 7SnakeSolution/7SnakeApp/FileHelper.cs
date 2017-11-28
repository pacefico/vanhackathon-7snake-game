using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7SnakeApp
{
    public class FileHelper
    {
        public static List<List<int>> GetArrayFromCSV(int size, string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            Console.WriteLine("Opening: " + path);
            List<List<int>> myArr = new List<List<int>>();

            using (var reader = new StreamReader(path))
            {
                int lineCount = 0;
                int thisLineCount = 0;
                while (!reader.EndOfStream)
                {
                    thisLineCount = 0;
                    List<int> line = new List<int>();
                    var myLine = reader.ReadLine();
                    foreach (string item in myLine.Split(';'))
                    {
                            
                        int myItemInt;
                        if (Int32.TryParse(item, out myItemInt))
                        {
                            line.Add(myItemInt);
                            thisLineCount++;
                        }
                        else
                        {
                            throw new FormatException(String.Format("Format of {0} is incorrect", item));
                        }
                    }

                    if (lineCount != 0 && lineCount != thisLineCount)
                    {
                        throw new ArgumentOutOfRangeException(
                            String.Format("The total amount of item per line is incorrect!." +
                            "\nFound: {1}, must be: {0}", lineCount, thisLineCount));
                    }
                    else
                    {
                        lineCount = thisLineCount;
                    }
                    myArr.Add(line);
                }
            }
            
            return myArr;
        }

        public static void GenerateNewCSV(int size, string path)
        {
            Random rand = new Random();

            using (StreamWriter outputFile = new StreamWriter(path))
            {
                for (int i = 0; i < size; i++)
                {
                    StringBuilder line = new StringBuilder();
                    for (int j = 0; j < size; j++)
                    {
                        line.Append(rand.Next(1, 256));
                        if (j < size - 1)
                        {
                            line.Append(";");
                        }
                    }
                    outputFile.WriteLine(line.ToString());
                }
            }
        }
    }
}
