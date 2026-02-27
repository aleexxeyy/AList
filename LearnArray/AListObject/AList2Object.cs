using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LearnArray.Interface.Object;

namespace LearnArray.NewList
{
    public class AList2Object<T> : IListObject<T>
    {
        private object[] arr;
        private int start;
        private int end;
        private int _index = -1;

        public AList2Object()
        {
            arr = new object[10]; 
            start = 0;
            end = -1;
        }

        public T Current
        {
            get
            {
                if (_index < start || _index > end)
                    throw new InvalidOperationException("Enumerator is positioned outside the range of the list.");
                return (T)arr[_index];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void AddEnd(T value)
        {
            EnsureCapacity(end + 2);
            arr[++end] = value;
        }

        public void AddPos(int index, T value)
        {
            if (index < 0 || index > end + 1)
                throw new ArgumentOutOfRangeException(nameof(index));

            EnsureCapacity(end + 2);
            for (int i = end; i >= index; i--)
            {
                arr[i + 1] = arr[i];
            }
            arr[index] = value;
            end++;
        }

        public void AddStart(T value)
        {
            AddPos(start, value);
        }

        public void Clear()
        {
            arr = new object[4];
            start = 0;
            end = -1;
        }

        public T DelEnd()
        {
            if (start > end)
                throw new InvalidOperationException("List is empty.");

            T value = (T)arr[end];
            arr[end--] = null;
            return value;
        }

        public T DelPos(int index)
        {
            if (index < start || index > end)
                throw new ArgumentOutOfRangeException(nameof(index));

            T value = (T)arr[index];
            for (int i = index; i < end; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[end--] = null;
            return value;
        }

        public T DelStart()
        {
            return DelPos(start);
        }

        public T Get(int index)
        {
            if (index < start || index > end)
                throw new ArgumentOutOfRangeException(nameof(index));

            return (T)arr[index];
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = start; i <= end; i++)
            {
                yield return arr[i];
            }
        }

        public void HalfReverse()
        {
            int mid = start + (end - start + 1) / 2 - 1;
            ReverseSegment(start, mid);
            ReverseSegment(mid + 1, end);
            ReverseSegment(start, end);
        }

        public int IndexMax()
        {
            if (start > end)
                throw new InvalidOperationException("List is empty.");

            int maxIndex = start;
            for (int i = start + 1; i <= end; i++)
            {
                if (Comparer<T>.Default.Compare((T)arr[i], (T)arr[maxIndex]) > 0)
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public int IndexMin()
        {
            if (start > end)
                throw new InvalidOperationException("List is empty.");

            int minIndex = start;
            for (int i = start + 1; i <= end; i++)
            {
                if (Comparer<T>.Default.Compare((T)arr[i], (T)arr[minIndex]) < 0)
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public void Init(T[] ini)
        {
            if (ini == null)
                throw new ArgumentNullException(nameof(ini));

            arr = new object[ini.Length];
            Array.Copy(ini, arr, ini.Length);
            start = 0;
            end = ini.Length - 1;
        }

        public T Max()
        {
            if (start > end)
                throw new InvalidOperationException("List is empty.");

            return (T)arr[IndexMax()];
        }

        public T Min()
        {
            if (start > end)
                throw new InvalidOperationException("List is empty.");

            return (T)arr[IndexMin()];
        }

        public void Reverse()
        {
            ReverseSegment(start, end);
        }

        public void Set(int index, T value)
        {
            if (index < start || index > end)
                throw new ArgumentOutOfRangeException(nameof(index));

            arr[index] = value;
        }

        public int Size()
        {
            return end - start + 1;
        }

        public void Sort()
        {
            QuickSort(start, end);
        }

        public T[] ToArray()
        {
            T[] result = new T[Size()];
            for (int i = start; i <= end; i++)
            {
                result[i - start] = (T)arr[i];
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                sb.Append(arr[i]);
            }
            return sb.ToString();
        }

        public bool MoveNext()
        {
            if (_index < end)
            {
                _index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _index = start - 1;
        }

        private void EnsureCapacity(int minCapacity)
        {
            if (arr.Length < minCapacity)
            {
                int newCapacity = arr.Length * 2;
                if (newCapacity < minCapacity)
                {
                    newCapacity = minCapacity;
                }
                object[] newArray = new object[newCapacity];
                Array.Copy(arr, start, newArray, 0, Size());
                arr = newArray;
                end = Size() - 1;
                start = 0;
            }
        }

        private void ReverseSegment(int start, int end)
        {
            while (start < end)
            {
                object temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        private void QuickSort(int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(low, high);
                QuickSort(low, pi - 1);
                QuickSort(pi + 1, high);
            }
        }

        private int Partition(int low, int high)
        {
            object pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (Comparer<T>.Default.Compare((T)arr[j], (T)pivot) < 0)
                {
                    i++;
                    Swap(i, j);
                }
            }
            Swap(i + 1, high);
            return i + 1;
        }

        private void Swap(int i, int j)
        {
            object temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
