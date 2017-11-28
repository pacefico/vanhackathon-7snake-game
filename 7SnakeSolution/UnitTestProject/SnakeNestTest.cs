using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using _7SnakeApp;
using System.Collections.Generic;
using _7SnakeApp.Factories;

namespace UnitTestProject
{
    [TestClass]
    public class SnakeNestTest
    {
        [TestMethod]
        public void TestSnakeNestIntegrated()
        {
            int size = 10;
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string name = String.Format("Data\\{0}x{0}.csv", size);
            var filePath = Path.Combine(path, name);
            List<List<int>> arr = FileHelper.GetArrayFromCSV(size, filePath);

            Assert.IsTrue(arr.Count == size);
            Assert.IsTrue(arr[0].Count == size);
            Assert.IsTrue(arr[size-1].Count == size);

            var nest = new SnakeNest(ref arr);

            var found = false;
            var i = 0;
            var j = 0;

            while (!found && i < size)
            {
                while (!found && j < size)
                {
                    found = nest.FeedFrom(i, j);
                    j++;
                }
                i++;
            }
            Assert.IsTrue(found);
            Assert.IsTrue(nest.SnakesFound.Count == 2);
            Assert.IsTrue(nest.SnakesFound[0].SnakeValue == 1188);
            Assert.IsTrue(nest.SnakesFound[1].NodeCount == 7);
            Assert.IsTrue(nest.SnakeCount == 178);
        }
    }
}
