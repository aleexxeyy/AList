using System;
using System.Linq;
using LearnArray.Interface.Generic;
using LearnArray.NewList;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LearnArray.Tests
{
    [TestFixture(typeof(AList2Generic<string>))]
    class AListGenericTests3<TList> where TList : IListGeneric<string>, new()
    {
        private IListGeneric<string> list = new TList();

        [TestCase(new string[] { "1", "2", "3" }, new string[] { "1", "2", "3" }, TestName = "Init 1")]
        [TestCase(new string[] { "0", "0", "0" }, new string[] { "0", "0", "0" }, TestName = "Init 2")]
        [TestCase(new string[] { "-1", "-2", "-3" }, new string[] { "-1", "-2", "-3" }, TestName = "Init 3")]
        public void InitTest1(string[] arr, string[] expected)
        {
            list.Init(arr);
            Assert.AreEqual(expected, list.ToArray());
        }

        [Test]
        public void InitTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1" }, "1", TestName = "Size 1")]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, "5", TestName = "Size 2")]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }, "10", TestName = "Size 3")]
        [TestCase(new string[] { }, "0", TestName = "Size 4")]
        public void SizeTest1(string[] arr, string expected)
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
        public void ClearTest1(string[] arr, string[] expected)
        {
            list.Init(arr);
            list.Clear();
            var result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ClearTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3" }, new string[] { "1", "2", "3" }, TestName = "ToArray 1")]
        [TestCase(new string[] { "0", "0", "0" }, new string[] { "0", "0", "0" }, TestName = "ToArray 2")]
        [TestCase(new string[] { "-1", "-2", "-3" }, new string[] { "-1", "-2", "-3" }, TestName = "ToArray 3")]
        public void ToArrayTest1(string[] arr, string[] expected)
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
        public void AddStartTest1(string[] arr, string value, string[] expected)
        {
            list.Init(arr);
            list.AddStart(value);
            string[] result = list.ToArray();
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void AddStartTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3" }, "4", new string[] { "1", "2", "3", "4" }, TestName = "AddEnd 1")]
        [TestCase(new string[] { "0", "0", "0" }, "1", new string[] { "0", "0", "0", "1" }, TestName = "AddEnd 2")]
        [TestCase(new string[] { "-1", "-2", "-3" }, "-4", new string[] { "-1", "-2", "-3", "-4" }, TestName = "AddEnd 3")]
        public void AddEndTest1(string[] arr, string value, string[] expected)
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
        public void AddPosTest1(string[] arr, int index, string value, string[] expected)
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
        public void DelStartTest1(string[] arr, string[] expected)
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
        public void DelEndTest2(string[] arr, string[] expected)
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
        [TestCase(new string[] { "0", "1", "0", "0" }, 1, new string[] { "0", "0", "0" }, TestName = "DelPos 2")]
        [TestCase(new string[] { "-1", "-2", "-3", "-4", "-5" }, 3, new string[] { "-1", "-2", "-3", "-5" }, TestName = "DelPos 3")]
        public void DelPosTest1(string[] arr, int pos, string[] expected)
        {
            list.Init(arr);
            list.DelPos(pos);
            string[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DelPosTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3" }, 1, "4", new string[] { "1", "4", "3" }, TestName = "Set 1")]
        [TestCase(new string[] { "0", "0", "0", "0" }, 2, "1", new string[] { "0", "0", "1", "0" }, TestName = "Set 2")]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, 3, "7", new string[] { "1", "2", "3", "7", "5" }, TestName = "Set 3")]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "7" }, 4, "6", new string[] { "1", "2", "3", "4", "6", "7" }, TestName = "Set 4")]
        public void SetTest1(string[] arr, int index, string value, string[] expected)
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

        [TestCase(new string[] { "2", "1", "3" }, 0, "2", TestName = "Get 1")]
        [TestCase(new string[] { "1", "2", "3" }, 1, "2", TestName = "Get 2")]
        [TestCase(new string[] { "0", "0", "1" }, 2, "1", TestName = "Get 3")]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, 3, "4", TestName = "Get 4")]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, 4, "5", TestName = "Get 5")]
        public void GetTest1(string[] arr, int index, string value)
        {
            list.Init(arr);
            string expected = value;
            string result = list.Get(index);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "1", "2", "3" }, new string[] { "3", "2", "1" }, TestName = "Reverse 1")]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "5", "4", "3", "2", "1" }, TestName = "Reverse 2")]
        public void ReverseTest1(string[] arr, string[] expected)
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
        [TestCase(new string[] { "0", "1", "1", "0" }, new string[] { "1", "0", "0", "1" }, TestName = "HalfReverse 2")]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6" }, new string[] { "4", "5", "6", "1", "2", "3" }, TestName = "HalfReverse 3")]
        public void HalfReverse_Test(string[] arr, string[] expected)
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

        [TestCase(new string[] { "1", "3", "2" }, "1", TestName = "Min 1")]
        [TestCase(new string[] { "4", "5", "3", "6" }, "3", TestName = "Min 2")]
        [TestCase(new string[] { "5", "8", "7", "4" }, "4", TestName = "Min 3")]
        public void MinTests1(string[] arr, string expected)
        {
            list.Init(arr);
            string result = list.Min();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MinTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "3", "1", "2" }, "3", TestName = "Max 1")]
        [TestCase(new string[] { "4", "5", "8", "6", "7" }, "8", TestName = "Max 2")]
        [TestCase(new string[] { "3", "4", "5", "7" }, "7", TestName = "Max 3")]
        public void MaxTest1(string[] arr, string expected)
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

        [TestCase(new string[] { "1", "2", "3" }, "0", TestName = "IndexMin 1")]
        [TestCase(new string[] { "4", "2", "3", "1", "5", "6" }, "3", TestName = "IndexMin 2")]
        [TestCase(new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "1" }, "9", TestName = "IndexMin 3")]
        public void IndexMinTests1(string[] arr, string expected)
        {
            list.Init(arr);
            string result = list.IndexMin().ToString();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IndexMinTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new string[] { "3", "2", "1" }, "0", TestName = "IndexMax 1")]
        [TestCase(new string[] { "4", "2", "3", "6", "1", "5" }, "3", TestName = "IndexMax 2")]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }, "8", TestName = "IndexMax 3")]
        public void IndexMaxTest1(string[] arr, string expected)
        {
            list.Init(arr);
            string result = list.IndexMax().ToString();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IndexMaxTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }


        [TestCase(new string[] { "1", "2", "4", "3" }, new string[] { "1", "2", "3", "4" }, TestName = "Sort 1")]
        [TestCase(new string[] { "4", "3", "2", "1" }, new string[] { "1", "2", "3", "4" }, TestName = "Sort 2")]
        [TestCase(new string[] { "-4", "-1", "-2", "-3" }, new string[] { "-1", "-2", "-3", "-4" }, TestName = "Sort 3")]
        public void SortTest1(string[] arr, string[] expected)
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
