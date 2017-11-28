using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _7SnakeApp;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void TestValidatorPositionResponseNotNull()
        {
            var response = Validator.Position(new Tuple<int, int>(1, 1), 2, 2);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestValidatorPositionMinLimit()
        {
            var response = Validator.Position(new Tuple<int, int>(0, 0), 10, 10);
            Assert.IsTrue(response.Count == 2);
        }

        [TestMethod]
        public void TestValidatorPositionMaxLimit()
        {
            var response = Validator.Position(new Tuple<int, int>(10, 10), 10, 10);
            Assert.IsTrue(response.Count == 2);
        }

        [TestMethod]
        public void TestValidatorPositionMiddle()
        {
            var response = Validator.Position(new Tuple<int, int>(5, 5), 10, 10);
            Assert.IsTrue(response.Count == 4);
        }

        [TestMethod]
        public void TestValidatorPositionValueMin()
        {
            var response = Validator.Position(new Tuple<int, int>(0, 0), 10, 10);
            Assert.IsTrue(response[0].Item1 == 0 && response[0].Item2 == 1);
            Assert.IsTrue(response[1].Item1 == 1 && response[1].Item2 == 0);
        }

        [TestMethod]
        public void TestValidatorPositionValueMax()
        {
            var response = Validator.Position(new Tuple<int, int>(10, 10), 10, 10);
            Assert.IsTrue(response[0].Item1 == 9 && response[0].Item2 == 10);
            Assert.IsTrue(response[1].Item1 == 10 && response[1].Item2 == 9);
        }

        [TestMethod]
        public void TestValidatorPositionValueMiddle()
        {
            var response = Validator.Position(new Tuple<int, int>(5, 5), 10, 10);
            Assert.IsTrue(response[0].Item1 == 5 && response[0].Item2 == 6);
            Assert.IsTrue(response[1].Item1 == 6 && response[1].Item2 == 5);
            Assert.IsTrue(response[2].Item1 == 4 && response[2].Item2 == 5);
            Assert.IsTrue(response[3].Item1 == 5 && response[3].Item2 == 4);
        }

        [TestMethod]
        public void TestValidatorMinAdjacents()
        {
            List<Tuple<int, int>> existent = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 0)
            };
            var node = new Tuple<int, int>(3, 0);
            var response = Validator.HasMinAdjacents(node, existent, 1, 10, 10);
            Assert.IsTrue(response);

            node = new Tuple<int, int>(1, 0);
            response = Validator.HasMinAdjacents(node, existent, 1, 10, 10);
            Assert.IsFalse(response);
        }
    }
}
