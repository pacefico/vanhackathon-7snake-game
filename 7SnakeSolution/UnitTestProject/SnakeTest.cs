using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _7SnakeApp.Model;

namespace UnitTestProject
{
    [TestClass]
    public class SnakeTests
    {
        [TestMethod]
        public void TestSnakeAddSingleNode()
        {
            var snake = new SnakeItem();

            var node = new Tuple<int, int>(1, 1);
            snake.AddNode(node, 10);
            Assert.IsTrue(snake.NodeCount == 1);
        }

        [TestMethod]
        public void TestSnakeCandAddNode()
        {
            var snake = new SnakeItem();

            var node = new Tuple<int, int>(1, 1);
            snake.AddNode(node, 10);

            node = new Tuple<int, int>(1, 1);
            var response = snake.CanAdd(node);

            Assert.IsTrue(snake.NodeCount == 1);
            Assert.IsFalse(response);
        }

        [TestMethod]
        public void TestSnakePeekNodeAndValue()
        {
            var snake = new SnakeItem();

            var node = new Tuple<int, int>(1, 1);
            snake.AddNode(node, 10);

            node = new Tuple<int, int>(1, 2);
            snake.AddNode(node, 20);

            Assert.IsTrue(snake.PeekNode().Item1 == 1 && snake.PeekNode().Item2 == 2);
            Assert.IsTrue(snake.SnakeValue == 30);
        }
    }
}
