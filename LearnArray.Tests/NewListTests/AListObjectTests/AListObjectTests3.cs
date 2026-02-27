using System;
using System.Linq;
using LearnArray.Interface.Object;
using LearnArray.NewList;
using NUnit.Framework;

namespace LearnArray.Tests
{
    [TestFixture(typeof(AList2Object<string>))]
    public class AListObjectTests3<TList> where TList : IListObject<string>, new()
    {
        private IListObject<string> list = new TList();

        [TestCase(new string[] { "1", "2", "3" }, new string[] { "1", "2", "3" }, TestName = "Init 1")]
        [TestCase(new string[] { "0", "0", "0" }, new string[] { "0", "0", "0" }, TestName = "Init 2")]
        [TestCase(new string[] { "-1", "-2", "-3" }, new string[] { "-1", "-2", "-3" }, TestName = "Init 3")]
        public void InitTests1(string[] arr, string[] expected)
        {
            list.Init(arr);
            Assert.AreEqual(expected, list.ToArray());
        }

        [Test]
        public void InitTests2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1" }, "1", TestName = "Size 1")]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, "5", TestName = "Size 2")]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }, "10", TestName = "Size 3")]
        [TestCase(new string[] { }, "0", TestName = "Size 4")]
        public void SizeTests1(string[] arr, string expected)
        {
            list.Init(arr);
            string result = list.Size().ToString();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SizeTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1" }, new string[] { }, TestName = "Clear 1")]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { }, TestName = "Clear 2")]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }, new string[] { }, TestName = "Clear 3")]
        public void ClearTests1(string[] arr, string[] expected)
        {
            list.Init(arr);
            list.Clear();
            var result = list.ToArray();
            Assert.AreEqual(expected, result);
            Assert.AreEqual(0, list.Size());
        }

        [Test]
        public void ClearTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1" }, new string[] { "1" }, TestName = "ToArray 1")]
        [TestCase(new string[] { "0", "0", "0" }, new string[] { "0", "0", "0" }, TestName = "ToArray 2")]
        [TestCase(new string[] { "-1", "-2", "-3" }, new string[] { "-1", "-2", "-3" }, TestName = "ToArray 3")]
        public void ToArrayTests1(string[] arr, string[] expected)
        {
            list.Init(arr);
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ToArrayTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3" }, "123", TestName = "ToString 1")]
        [TestCase(new string[] { "0", "0", "0" }, "000", TestName = "ToString 2")]
        [TestCase(new string[] { "-1", "-2", "-3" }, "-1-2-3", TestName = "ToString 3")]
        public void ToStringTest1(string[] arr, string expected)
        {
            list.Init(arr);
            string result = list.ToString();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ToStringTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3" }, "4", new string[] { "4", "1", "2", "3" }, TestName = "AddStart 1")]
        [TestCase(new string[] { "0", "0", "0" }, "1", new string[] { "1", "0", "0", "0" }, TestName = "AddStart 2")]
        [TestCase(new string[] { "-1", "-2", "-3" }, "-4", new string[] { "-4", "-1", "-2", "-3" }, TestName = "AddStart 3")]
        public void AddStartTests1(string[] arr, string value, string[] expected)
        {
            list.Init(arr);
            list.AddStart(value);
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddStartTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3" }, "4", new string[] { "1", "2", "3", "4" }, TestName = "AddEnd 1")]
        [TestCase(new string[] { "0", "0", "0" }, "1", new string[] { "0", "0", "0", "1" }, TestName = "AddEnd 2")]
        [TestCase(new string[] { "-1", "-2", "-3" }, "-4", new string[] { "-1", "-2", "-3", "-4" }, TestName = "AddEnd 3")]
        public void AddEndTests1(string[] arr, string value, string[] expected)
        {
            list.Init(arr);
            list.AddEnd(value);
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddEndTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3" }, 2, "4", new string[] { "1", "2", "4", "3" }, TestName = "AddPos 1")]
        [TestCase(new string[] { "0", "0", "0" }, 2, "1", new string[] { "0", "0", "1", "0" }, TestName = "AddPos 2")]
        [TestCase(new string[] { "-1", "-2", "-3" }, 1, "-4", new string[] { "-1", "-4", "-2", "-3" }, TestName = "AddPos 3")]
        public void AddPosTests1(string[] arr, int index, string value, string[] expected)
        {
            list.Init(arr);
            list.AddPos(index, value);
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddPosTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "4", "1", "2", "3" }, new string[] { "1", "2", "3" }, TestName = "DelStart 1")]
        [TestCase(new string[] { "1", "0", "0", "0" }, new string[] { "0", "0", "0" }, TestName = "DelStart 2")]
        [TestCase(new string[] { "-4", "-1", "-2", "-3" }, new string[] { "-1", "-2", "-3" }, TestName = "DelStart 3")]
        public void DelStartTests1(string[] arr, string[] expected)
        {
            list.Init(arr);
            list.DelStart();
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DelStartTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3", "4" }, new string[] { "1", "2", "3" }, TestName = "DelEnd 1")]
        [TestCase(new string[] { "0", "0", "0", "1" }, new string[] { "0", "0", "0" }, TestName = "DelEnd 2")]
        [TestCase(new string[] { "-1", "-2", "-3", "-4" }, new string[] { "-1", "-2", "-3" }, TestName = "DelEnd 3")]
        public void DelEndTests1(string[] arr, string[] expected)
        {
            list.Init(arr);
            list.DelEnd();
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DelEndTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3", "4" }, 2, new string[] { "1", "2", "4" }, TestName = "DelPos 1")]
        [TestCase(new string[] { "0", "0", "0", "1" }, 2, new string[] { "0", "0", "1" }, TestName = "DelPos 2")]
        [TestCase(new string[] { "-1", "-2", "-3", "-4" }, 1, new string[] { "-1", "-3", "-4" }, TestName = "DelPos 3")]
        public void DelPosTests1(string[] arr, int index, string[] expected)
        {
            list.Init(arr);
            list.DelPos(index);
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DelPosTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3" }, 1, "4", new string[] { "1", "4", "3" }, TestName = "Set 1")]
        [TestCase(new string[] { "0", "0", "0", "1" }, 2, "5", new string[] { "0", "0", "5", "1" }, TestName = "Set 2")]
        [TestCase(new string[] { "-1", "-2", "-3", "-4" }, 0, "0", new string[] { "0", "-2", "-3", "-4" }, TestName = "Set 3")]
        public void SetTests1(string[] arr, int index, string value, string[] expected)
        {
            list.Init(arr);
            list.Set(index, value);
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SetTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3", "4" }, 2, "3", TestName = "Get 1")]
        [TestCase(new string[] { "0", "0", "0", "1" }, 3, "1", TestName = "Get 2")]
        [TestCase(new string[] { "-1", "-2", "-3", "-4" }, 1, "-2", TestName = "Get 3")]
        public void GetTests1(string[] arr, int index, string expected)
        {
            list.Init(arr);
            string result = list.Get(index);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3", "4" }, new string[] { "4", "3", "2", "1" }, TestName = "Reverse 1")]
        [TestCase(new string[] { "0", "1", "2", "3" }, new string[] { "3", "2", "1", "0" }, TestName = "Reverse 2")]
        [TestCase(new string[] { "-1", "-2", "-3", "-4" }, new string[] { "-4", "-3", "-2", "-1" }, TestName = "Reverse 3")]
        public void ReverseTests1(string[] arr, string[] expected)
        {
            list.Init(arr);
            list.Reverse();
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3", "4" }, new string[] { "3", "4", "1", "2" }, TestName = "HalfReverse 1")]
        [TestCase(new string[] { "0", "1", "2", "3" }, new string[] { "2", "3", "0", "1" }, TestName = "HalfReverse 2")]
        [TestCase(new string[] { "-1", "-2", "-3", "-4" }, new string[] { "-3", "-4", "-1", "-2" }, TestName = "HalfReverse 3")]
        public void HalfReverseTests1(string[] arr, string[] expected)
        {
            list.Init(arr);
            list.HalfReverse();
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void HalfReverseTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3", "4" }, "1", TestName = "Min 1")]
        [TestCase(new string[] { "4", "3", "2", "1" }, "1", TestName = "Min 2")]
        [TestCase(new string[] { "-1", "-2", "-3", "-4" }, "-1", TestName = "Min 3")]
        public void MinTests1(string[] arr, string expected)
        {
            list.Init(arr);
            string result = list.Min();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MinTests2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3", "4" }, "4", TestName = "Max 1")]
        [TestCase(new string[] { "4", "3", "2", "1" }, "4", TestName = "Max 2")]
        [TestCase(new string[] { "1", "2", "3", "4" }, "4", TestName = "Max 1")]
        [TestCase(new string[] { "4", "3", "2", "1" }, "4", TestName = "Max 2")]
        [TestCase(new string[] { "-1", "-2", "-3", "-4" }, "-4", TestName = "Max 3")]
        public void MaxTests1(string[] arr, string expected)
        {
            list.Init(arr);
            string result = list.Max();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3", "4" }, "0", TestName = "IndexMin 1")]
        [TestCase(new string[] { "4", "3", "2", "1" }, "3", TestName = "IndexMin 2")]
        [TestCase(new string[] { "-2", "-1", "-3", "-4" }, "1", TestName = "IndexMin 3")]
        public void IndexMinTests1(string[] arr, string expectedIndex)
        {
            list.Init(arr);
            string result = list.IndexMin().ToString();
            Assert.AreEqual(expectedIndex, result);
        }

        [Test]
        public void IndexMinTests2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3", "4" }, "3", TestName = "IndexMax 1")]
        [TestCase(new string[] { "4", "3", "2", "1" }, "0", TestName = "IndexMax 2")]
        [TestCase(new string[] { "-1", "-2", "-4", "-3" }, "2", TestName = "IndexMax 3")]
        public void IndexMaxTests1(string[] arr, string expectedIndex)
        {
            list.Init(arr);
            string result = list.IndexMax().ToString();
            Assert.AreEqual(expectedIndex, result);
        }

        [Test]
        public void IndexMaxTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "4", "3" }, new string[] { "1", "2", "3", "4" }, TestName = "Sort 1")]
        [TestCase(new string[] { "4", "3", "2", "1" }, new string[] { "1", "2", "3", "4" }, TestName = "Sort 2")]
        [TestCase(new string[] { "-4", "-1", "-2", "-3" }, new string[] { "-1", "-2", "-3", "-4" }, TestName = "Sort 3")]
        public void SortTests1(string[] arr, string[] expected)
        {
            list.Init(arr);
            list.Sort();
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SortTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }
    }
}