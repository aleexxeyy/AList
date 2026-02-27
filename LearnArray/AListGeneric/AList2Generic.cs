using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LearnArray.Interface.Generic;

namespace LearnArray.NewList
{
    public class AList2Generic<T> : IListGeneric<T> 
    {
        private T[] arr;
        private int start;
        private int end;

        public object Current => throw new NotImplementedException();
        public bool MoveNext() => throw new NotImplementedException();
        public void Reset() => throw new NotImplementedException();

        public AList2Generic()
        {
            arr = new T[10];
            start = 0;
            end = 0;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = start; i < end; i++)
            {
                yield return arr[i]; // Возвращает текущий элемент и приостанавливает выполнение
            }
        }

        public void Init(T[] ini)
        {
            if (ini == null)
            {
                throw new ArgumentNullException(nameof(ini));
            }

            arr = new T[ini.Length];
            for (int i = 0; i < ini.Length; i++)
            {
                arr[i] = ini[i];
            }
            start = 0;
            end = ini.Length;
        }

        public int Size()
        {
            return end - start;
        }

        public void Clear()
        {
            arr = new T[10];
            start = 0;
            end = 0;
        }

        public T[] ToArray()
        {
            T[] result = new T[Size()];
            for (int i = 0; i < Size(); i++)
            {
                result[i] = arr[start + i];
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = start; i < end; i++)
            {
                sb.Append(arr[i]);
            }
            return sb.ToString();
        }

        public void AddStart(T value)
        {
            if (start == 0)
            {
                // Увеличиваем размер массива и сдвигаем элементы вправо
                int newCapacity = arr.Length * 2;
                T[] newArr = new T[newCapacity];
                int shift = newCapacity / 4;
                Array.Copy(arr, 0, newArr, shift, end);
                arr = newArr;
                start = shift;
                end += shift;
            }
            start--;
            arr[start] = value;
        }

        public void AddEnd(T value)
        {
            if (end >= arr.Length)
            {
                // Увеличиваем размер массива
                int newCapacity = arr.Length * 2;
                T[] newArr = new T[newCapacity];
                Array.Copy(arr, 0, newArr, 0, end);
                arr = newArr;
            }
            arr[end] = value;
            end++;
        }

        public void AddPos(int index, T value)
        {
            if (index < 0 || index > end - start)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            if (end >= arr.Length)
            {
                // Увеличиваем размер массива
                int newCapacity = arr.Length * 2;
                T[] newArr = new T[newCapacity];
                Array.Copy(arr, 0, newArr, 0, end);
                arr = newArr;
            }

            for (int i = end; i > start + index; i--)
            {
                arr[i] = arr[i - 1];
            }

            arr[start + index] = value;
            end++;
        }

        public T DelStart()
        {
            if (Size() == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            T value = arr[start];
            arr[start] = default(T);
            start++;
            return value;
        }

        public T DelEnd()
        {
            if (Size() == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            end--;
            T value = arr[end];
            arr[end] = default(T);
            return value;
        }

        public T DelPos(int index)
        {
            if (index < 0 || index >= Size())
            {
                throw new ArgumentOutOfRangeException();
            }
            T value = arr[start + index];
            for (int i = start + index; i < end - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            end--;
            arr[end] = default(T);
            return value;
        }

        public void Set(int index, T value)
        {
            if (index < 0 || index >= Size())
            {
                throw new ArgumentOutOfRangeException();
            }
            arr[start + index] = value;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Size())
            {
                throw new ArgumentOutOfRangeException();
            }
            return arr[start + index];
        }

        public void Reverse()
        {
            for (int i = 0; i < Size() / 2; i++)
            {
                T temp = arr[start + i];
                arr[start + i] = arr[end - 1 - i];
                arr[end - 1 - i] = temp;
            }
        }

        public void HalfReverse()
        {
            int mid = Size() / 2;
            int offset = Size() % 2 == 0 ? 0 : 1;
            for (int i = 0; i < mid; i++)
            {
                T temp = arr[start + i];
                arr[start + i] = arr[start + mid + offset + i];
                arr[start + mid + offset + i] = temp;
            }
        }

        public T Min()
        {
            if (Size() == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            T min = arr[start];
            for (int i = start + 1; i < end; i++)
            {
                if (((IComparable)arr[i]).CompareTo(min) < 0)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        public T Max()
        {
            if (Size() == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            T max = arr[start];
            for (int i = start + 1; i < end; i++)
            {
                if (((IComparable)arr[i]).CompareTo(max) > 0)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        public int IndexMin()
        {
            if (Size() == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            int minIndex = start;
            for (int i = start + 1; i < end; i++)
            {
                if (((IComparable)arr[i]).CompareTo(arr[minIndex]) < 0)
                {
                    minIndex = i;
                }
            }
            return minIndex - start;
        }

        public int IndexMax()
        {
            if (Size() == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            int maxIndex = start;
            for (int i = start + 1; i < end; i++)
            {
                if (((IComparable)arr[i]).CompareTo(arr[maxIndex]) > 0)
                {
                    maxIndex = i;
                }
            }
            return maxIndex - start;
        }

        public void Sort()
        {
            for (int i = start; i < end - 1; i++)
            {
                for (int j = start; j < end - i - 1; j++)
                {
                    if ((arr[j] as IComparable).CompareTo(arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
