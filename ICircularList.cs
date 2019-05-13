using System;
namespace CircularList
{
    public interface ICircularList
    {
        ArrayIndexInfo Min();
        ArrayIndexInfo Max();
        int Avg();
        int Sum();

        void Insert(int value);
        void RemoveAt(int index);
        void Clear();
        void Print();
    }
}
