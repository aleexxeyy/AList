using System;
using System.Linq;
using LearnArray.Interface.Generic;
using LearnArray.NewList;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LearnArray.Tests
{

    [TestFixture(typeof(AList2Generic<float>))]
    class AListGenericTests2<TList> where TList : IListGeneric<float>, new()
    {
        private IListGeneric<float> list = new TList();


        [TestCase(new float[] { 1f, 2f, 3f }, new float[] { 1f, 2f, 3f }, TestName = "Init 1")]
        [TestCase(new float[] { 0f, 0f, 0f }, new float[] { 0f, 0f, 0f }, TestName = "Init 2")]
        [TestCase(new float[] { -1f, -2f, -3f }, new float[] { -1f, -2f, -3f }, TestName = "Init 3")]
        public void InitTest1(float[] arr, float[] expected)
        {
            list.Init(arr);

            Assert.AreEqual(expected, list.ToArray());
        }

        [Test]
        public void InitTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f }, 1f, TestName = "Size 1")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f }, 5f, TestName = "Size 2")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f }, 10f, TestName = "Size 3")]
        [TestCase(new float[] { }, 0f, TestName = "Size 4")]
        public void SizeTest1(float[] arr, float expected)
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
        public void ClearTest1(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.Clear();
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(0, list.Size());
        }

        [Test]
        public void ClearTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f }, new float[] { 1f, 2f, 3f }, TestName = "ToArray 1")]
        [TestCase(new float[] { 0f, 0f, 0f }, new float[] { 0f, 0f, 0f }, TestName = "ToArray 2")]
        [TestCase(new float[] { -1f, -2f, -3f }, new float[] { -1f, -2f, -3f }, TestName = "ToArray 3")]
        public void ToArrayTest1(float[] arr, float[] expected)
        {
            list.Init(arr);
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
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
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public void ToStringTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f }, 4f, new float[] { 4f, 1f, 2f, 3f }, TestName = "AddStart 1")]
        [TestCase(new float[] { 0f, 0f, 0f }, 1f, new float[] { 1f, 0f, 0f, 0f }, TestName = "AddStart 2")]
        [TestCase(new float[] { -1f, -2f, -3f }, -4f, new float[] { -4f, -1f, -2f, -3f }, TestName = "AddStart 3")]
        public void AddStartTest1(float[] arr, float value, float[] expected)
        {
            list.Init(arr);
            list.AddStart(value);
            float[] result = list.ToArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void AddStartTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f }, 4f, new float[] { 1f, 2f, 3f, 4f }, TestName = "AddEnd 1")]
        [TestCase(new float[] { 0f, 0f, 0f }, 1f, new float[] { 0f, 0f, 0f, 1f }, TestName = "AddEnd 2")]
        [TestCase(new float[] { -1f, -2f, -3f }, -4f, new float[] { -1f, -2f, -3f, -4f }, TestName = "AddEnd 3")]
        public void AddEndTest1(float[] arr, float value, float[] expected)
        {
            list.Init(arr);
            list.AddEnd(value);
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public void AddEndTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1, 2, 3 }, 2, 4, new float[] { 1, 2, 4, 3 }, TestName = "AddPos 1")]
        [TestCase(new float[] { 0, 0, 0 }, 2, 1, new float[] { 0, 0, 1, 0 }, TestName = "AddPos 2")]
        [TestCase(new float[] { -1, -2, -3 }, 1, -4, new float[] { -1, -4, -2, -3 }, TestName = "AddPos 3")]
        public void AddPosTest1(float[] arr, int index, float value, float[] expected)
        {
            list.Init(arr);
            list.AddPos(index, value);
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public void AddPosTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }
        
        [TestCase(new float[] { 4f, 1f, 2f, 3f }, new float[] { 1f, 2f, 3f }, TestName = "DelStart 1")]
        [TestCase(new float[] { 1f, 0f, 0f, 0f }, new float[] { 0f, 0f, 0f }, TestName = "DelStart 2")]
        [TestCase(new float[] { -4f, -1f, -2f, -3f }, new float[] { -1f, -2f, -3f }, TestName = "DelStart 3")]
        public void DelStartTest1(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.DelStart();
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public void DelStartTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, new float[] { 1f, 2f, 3f }, TestName = "DelEnd 1")]
        [TestCase(new float[] { 0f, 0f, 0f, 1f }, new float[] { 0f, 0f, 0f }, TestName = "DelEnd 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4f }, new float[] { -1f, -2f, -3f  }, TestName = "DelEnd 3")]
        public void DelEndTest2(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.DelEnd();
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public void DelEndTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, 2, new float[] { 1f, 2f, 4f }, TestName = "DelPos 1")]
        [TestCase(new float[] { 0f, 1f, 0f, 0f }, 1, new float[] { 0f, 0f, 0f }, TestName = "DelPos 2")]
        [TestCase(new float[] { -1f, -2f, -3f, -4, -5 }, 3, new float[] { -1f, -2f, -3f, -5f }, TestName = "DelPos 3")]
        public void DelPosTest1(float[] arr, int pos, float[] expected)
        {
            list.Init(arr);
            list.DelPos(pos);
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public void DelPosTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f }, 1, 4f, new float[] { 1, 4, 3 }, TestName = "Set 1")]
        [TestCase(new float[] { 0f, 0f, 0f, 0f }, 2, 1f, new float[] { 0, 0, 1, 0 }, TestName = "Set 2")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f }, 3, 7f, new float[] { 1, 2, 3, 7, 5 }, TestName = "Set 3")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f, 7f }, 4, 6f, new float[] { 1, 2, 3, 4, 6, 7 }, TestName = "Set 4")]
        public void SetTest1(float[] arr, int index, float value, float[] expected)
        {
            list.Init(arr);
            list.Set(index, value);
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public void SetTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 2f, 1f, 3f }, 0, 2f, TestName = "Get 1")]
        [TestCase(new float[] { 1f, 2f, 3f }, 1, 2f, TestName = "Get 2")]
        [TestCase(new float[] { 0f, 0f, 1f }, 2, 1f, TestName = "Get 3")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f }, 3, 4f, TestName = "Get 4")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f }, 4, 5f, TestName = "Get 5")]
        public void GetTest1(float[] arr, int index, float value)
        {
            list.Init(arr);
            float expected = value;
            float result = list.Get(index);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f }, new float[] { 3f, 2f, 1f }, TestName = "Reverse 1")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f }, new float[] { 5f, 4f, 3f, 2f, 1f }, TestName = "Reverse 2")]
        public void ReverseTest1(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.Reverse();
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public void ReverseTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f, 4f }, new float[] { 3f, 4f, 1f, 2f }, TestName = "HalfReverse 1")]
        [TestCase(new float[] { 0f, 1f, 1f, 0f }, new float[] { 1f, 0f, 0f, 1f }, TestName = "HalfReverse 2")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f, 6f }, new float[] { 4f, 5f, 6f, 1f, 2f, 3f }, TestName = "HalfReverse 3")]
        public void HalfReverse_Test(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.HalfReverse();
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public void HalfReverseTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 3f, 2f }, 1f, TestName = "Min 1")]
        [TestCase(new float[] { 4f, 5f, 3f, 6f }, 3f, TestName = "Min 2")]
        [TestCase(new float[] { 5f, 8f, 7f, 4f }, 4f, TestName = "Min 3")]
        public void MinTest1(float[] arr, float expected)
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

        [TestCase(new float[] { 3f, 1f, 2f }, 3f, TestName = "Max 1")]
        [TestCase(new float[] { 4f, 5f, 8f, 6f, 7f }, 8f, TestName = "Max 2")]
        [TestCase(new float[] { 3f, 4f, 5f, 7f }, 7f, TestName = "Max 3")]
        public void MaxTest1(float[] arr, float expected)
        {
            list.Init(arr);
            float result = list.Max();
            list.ToArray();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 1f, 2f, 3f }, 0f, TestName = "IndexMin 1")]
        [TestCase(new float[] { 4f, 2f, 3f, 1f, 5f, 6f }, 3f, TestName = "IndexMin 2")]
        [TestCase(new float[] { 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 1f }, 9f, TestName = "IndexMin 3")]
        public void IndexMinTest1(float[] arr, float expected)
        {
            list.Init(arr);
            float result = list.IndexMin();

            Assert.AreEqual(expected, result);

        }

        [Test]
        public void IndexMinTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 3f, 2f, 1f }, 0f, TestName = "IndeMax 1")]
        [TestCase(new float[] { 4f, 2f, 3f, 6f, 1f, 5f }, 3f, TestName = "IndexMax 2")]
        [TestCase(new float[] { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f }, 9f, TestName = "IndexMax 3")]
        public void IndexMaxTest1(float[] arr, float expected)
        {
            list.Init(arr);
            float result = list.IndexMax();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IndexMaxTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new float[] { 2f, 1f, 3f }, new float[] { 1f, 2f, 3f }, TestName = "Sort 1")]
        [TestCase(new float[] { 2f, 1f, 3f, 5f, 4f }, new float[] { 1f, 2f, 3f, 4f, 5f }, TestName = "Sort 2")]
        [TestCase(new float[] { 1f, 2f, 3f, 6f, 4f, 5f, 7f, 10f, 9f, 8f }, new float[] { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f }, TestName = "Sort 3")]
        public void SortTest1(float[] arr, float[] expected)
        {
            list.Init(arr);
            list.Sort();
            float[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public void SortTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }
    }
}