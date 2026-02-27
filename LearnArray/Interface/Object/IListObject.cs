using System.Collections;

namespace LearnArray.Interface.Object
{
    public interface IListObject<T>: IEnumerable, IEnumerator
    {
        void Init(T[] ini);
        int Size();
        void Clear();
        T[] ToArray();
        string ToString();
        void AddStart(T value);
        void AddEnd(T value);
        void AddPos(int index, T value);
        T DelStart();
        T DelEnd();
        T DelPos(int index);
        void Set(int index, T value);
        T Get(int index);
        void Reverse();
        void HalfReverse();
        T Min();
        T Max();
        int IndexMin();
        int IndexMax();
        void Sort();
    }
}
