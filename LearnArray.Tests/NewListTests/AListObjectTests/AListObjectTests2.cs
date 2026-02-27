using System;
using System.Linq;
using LearnArray.Interface.Object;
using LearnArray.NewList;
using NUnit.Framework;

namespace LearnArray.Tests
{

    [TestFixture(typeof(AList2Object<float>))]
    public class AListObjectTests2<TList> where TList : IListObject<float>, new()
    {
        private IListObject<float> list = new TList();

        [TestCase(new float[] { 1f, 2f, 3f }, new float[] { 1f, 2f, 3f }, TestName = "Init 1")]
        [TestCase(new float[] { 0f, 0f, 0f }, new float[] { 0f, 0f, 0f }, TestName = "Init 2")]
        [TestCase(new float[] { -1f, -2f, -3f }, new float[] { -1f, -2f, -3f }, TestName = "Init 3")]
        public void InitTests1(float[] arr, float[] expected)
        {
            list.Init(arr);
            Assert.AreEqual(expected, list.ToArray());
        }

        [Test]
        public void InitTests2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f }, 1f, TestName = "Size 1")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f }, 5f, TestName = "Size 2")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f }, 10f, TestName = "Size 3")]
        [TestCase(new float[] { }, 0f, TestName = "Size 4")]
        public void SizeTests1(float[] arr, float expected)
        {
            list.Init(arr);
            float result = list.Size();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SizeTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f }, new float[] { }, TestName = "Clear 1")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f }, new float[] { }, TestName = "Clear 2")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f }, new float[] { }, TestName = "Clear 3")]
        public void ClearTests1(float[] arr, float[] expected)
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

        [TestCase(new float[] { 1f }, new float[] { 1f }, TestName = "ToArray 1")]
        [TestCase(new float[] { 0f, 0f, 0f }, new float[] { 0f, 0f, 0f }, TestName = "ToArray 2")]
        [TestCase(new float[] { -1f, -2f, -3f }, new float[] { -1f, -2f, -3f }, TestName = "ToArray 3")]
        public void ToArrayTests1(float[] arr, float[] expected)
        {
            list.Init(arr);
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ToArrayTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f }, "123", TestName = "ToString 1")]
        [TestCase(new float[] { 0f, 0f, 0f }, "000", TestName = "ToString 2")]
        [TestCase(new float[] { -1f, -2f, -3f }, "-1-2-3", TestName = "ToString 3")]
        public void ToStringTest1(float[] arr, string expected)
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

        [TestCase(new float[] { 1f, 2f, 3f }, 4f, new float[] { 4f, 1f, 2f, 3f }, TestName = "AddStart 1")]
        [TestCase(new float[] { 0f, 0f, 0f }, 1f, new float[] { 1f, 0f, 0f, 0f }, TestName = "AddStart 2")]
        [TestCase(new float[] { -1f, -2f, -3f }, -4f, new float[] { -4f, -1f, -2f, -3f }, TestName = "AddStart 3")]
        public void AddStartTests1(float[] arr, float value, float[] expected)
        {
            list.Init(arr);
            list.AddStart(value);
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddStartTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f }, 4f, new float[] { 1f, 2f, 3f, 4f }, TestName = "AddEnd 1")]
        [TestCase(new float[] { 0f, 0f, 0f }, 1f, new float[] { 0f, 0f, 0f, 1f }, TestName = "AddEnd 2")]
        [TestCase(new float[] { -1f, -2f, -3f }, -4f, new float[] { -1f, -2f, -3f, -4f }, TestName = "AddEnd 3")]
        public void AddEndTests1(float[] arr, float value, float[] expected)
        {
            list.Init(arr);
            list.AddEnd(value);
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddEndTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f }, 2, 4f, new float[] { 1f, 2f, 4f, 3f }, TestName = "AddPos 1")]
        [TestCase(new float[] { 0f, 0f, 0f }, 2, 1f, new float[] { 0f, 0f, 1f, 0f }, TestName = "AddPos 2")]
        [TestCase(new float[] { -1f, -2f, -3f }, 1, -4f, new float[] { -1f, -4f, -2f, -3f }, TestName = "AddPos 3")]
        public void AddPosTests1(float[] arr, int index, float value, float[] expected)
        {
            list.Init(arr);
            list.AddPos(index, value);
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddPosTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 4f, 1f, 2f, 3f }, new float[] { 1f, 2f, 3f }, TestName = "DelStart 1")]
        [TestCase(new float[] { 1f, 0f, 0f, 0f }, new float[] { 0f, 0f, 0f }, TestName = "DelStart 2")]
        [TestCase(new float[] { -4f, -1f, -2f, -3f }, new float[] { -1f, -2f, -3f }, TestName = "DelStart 3")]
        public void DelStartTests1(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.DelStart();
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DelStartTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, new float[] { 1f, 2f, 3f }, TestName = "DelEnd 1")]
        [TestCase(new float[] { 0f, 0f, 0f, 1f }, new float[] { 0f, 0f, 0f }, TestName = "DelEnd 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, new float[] { -1f, -2f, -3f }, TestName = "DelEnd 3")]
        public void DelEndTests1(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.DelEnd();
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DelEnTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, 2, new float[] { 1f, 2f, 4f }, TestName = "DelPos 1")]
        [TestCase(new float[] { 0f, 0f, 0f, 1f }, 2, new float[] { 0f, 0f, 1f }, TestName = "DelPos 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, 1, new float[] { -1f, -3f, -4f }, TestName = "DelPos 3")]
        public void DelPosTests1(float[] arr, int index, float[] expected)
        {
            list.Init(arr);
            list.DelPos(index);
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DelPosTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f }, 1, 4f, new float[] { 1f, 4f, 3f }, TestName = "Set 1")]
        [TestCase(new float[] { 0f, 0f, 0f, 1f }, 2, 5f, new float[] { 0f, 0f, 5f, 1f }, TestName = "Set 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, 0, 0f, new float[] { 0f, -2f, -3f, -4f }, TestName = "Set 3")]
        public void SetTests1(float[] arr, int index, float value, float[] expected)
        {
            list.Init(arr);
            list.Set(index, value);
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SetTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, 2, 3f, TestName = "Get 1")]
        [TestCase(new float[] { 0f, 0f, 0f, 1f }, 3, 1f, TestName = "Get 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, 1, -2f, TestName = "Get 3")]
        public void GetTests1(float[] arr, int index, float expected)
        {
            list.Init(arr);
            float result = list.Get(index);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, new float[] { 4f, 3f, 2f, 1f }, TestName = "Reverse 1")]
        [TestCase(new float[] { 0f, 1f, 2f, 3f }, new float[] { 3f, 2f, 1f, 0f }, TestName = "Reverse 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, new float[] { -4f, -3f, -2f, -1f }, TestName = "Reverse 3")]
        public void ReverseTests1(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.Reverse();
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, new float[] { 3f, 4f, 1f, 2f }, TestName = "HalfReverse 1")]
        [TestCase(new float[] { 0f, 1f, 2f, 3f }, new float[] { 2f, 3f, 0f, 1f }, TestName = "HalfReverse 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, new float[] { -3f, -4f, -1f, -2f }, TestName = "HalfReverse 3")]
        public void HalfReverseTests1(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.HalfReverse();
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void HalfReverseTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, 1f, TestName = "Min 1")]
        [TestCase(new float[] { 4f, 3f, 2f, 1f }, 1f, TestName = "Min 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, -4f, TestName = "Min 3")]
        public void MinTests1(float[] arr, float expected)
        {
            list.Init(arr);
            float result = list.Min();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MinTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, 4f, TestName = "Max 1")]
        [TestCase(new float[] { 4f, 3f, 2f, 1f }, 4f, TestName = "Max 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, -1f, TestName = "Max 3")]
        public void MaxTests1(float[] arr, float expected)
        {
            list.Init(arr);
            float result = list.Max();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, 0f, TestName = "IndexMin 1")]
        [TestCase(new float[] { 4f, 3f, 2f, 1f }, 3f, TestName = "IndexMin 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, 3f, TestName = "IndexMin 3")]
        public void IndexMfloatests1(float[] arr, float expectedIndex)
        {
            list.Init(arr);
            float result = list.IndexMin();
            Assert.AreEqual(expectedIndex, result);
        }

        [Test]
        public void IndexMfloatest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, 3f, TestName = "IndexMax 1")]
        [TestCase(new float[] { 4f, 3f, 2f, 1f }, 0f, TestName = "IndexMax 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, 0f, TestName = "IndexMax 3")]
        public void IndexMaxTests1(float[] arr, float expectedIndex)
        {
            list.Init(arr);
            float result = list.IndexMax();
            Assert.AreEqual(expectedIndex, result);
        }

        [Test]
        public void IndexMaxTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, new float[] { 1f, 2f, 3f, 4f }, TestName = "Sort 1")]
        [TestCase(new float[] { 4f, 2f, 3f, 1f }, new float[] { 1f, 2f, 3f, 4f }, TestName = "Sort 2")]
        [TestCase(new float[] { -4f, -3f, -1f, -2f }, new float[] { -4f, -3f, -2f, -1f }, TestName = "Sort 3")]
        public void SortTests1(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.Sort();
            float[] result = list.ToArray();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SortTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }
    }
}
