using System;
namespace CircularList
{
    public class CircularList : ICircularList
    {
        private int[] m_circularListArr;

        /// <summary>
        ///     Gets the <see cref="T:CircularList.CircularList"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public int this[int index]
        {
            get
            {
                return m_circularListArr[index];
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:CircularList.CircularList"/> class.
        /// </summary>
        public CircularList()
        {
            m_circularListArr = new int[0];
        }

        /// <summary>
        ///     Insert the specified value.
        /// </summary>
        /// <param name="value">Value.</param>
        public void Insert(int value)
        {
            int length = m_circularListArr.Length + 1;
            int[] result = new int[length];

            for (int i = 0; i < length - 1; i++)
            {
                result[i] = m_circularListArr[i];
            }
            result[length - 1] = value;
            m_circularListArr = result;
        }

        /// <summary>
        ///     Removes at index.
        /// </summary>
        /// <param name="index">Index.</param>
        public void RemoveAt(int index)
        {
            int length = m_circularListArr.Length - 1;
            int[] result = new int[length];

            if (index < length + 1)
            {
                int counter = 0;

                for (int i = 0; i < length + 1; i++)
                {
                    if (index == i) continue;

                    result[counter] = m_circularListArr[i];
                    counter++;
                }
                m_circularListArr = result;
            }
            else
            {
                Console.WriteLine("[ERROR]: Invalid index!");
            }
        }

        /// <summary>
        ///     Gets the previous.
        /// </summary>
        /// <returns>The previous.</returns>
        /// <param name="minimum">Minimum.</param>
        public ArrayIndexInfo GetPrevious(ArrayIndexInfo minimum)
        {
            return GetPreviousBeforeMinimum(minimum);
        }

        /// <summary>
        ///     Gets minimum value
        /// </summary>
        /// <returns>The minimum.</returns>
        public ArrayIndexInfo Min()
        {
            return GetMinimumValueWithIndex();
        }

        /// <summary>
        ///     Gets Average
        /// </summary>
        /// <returns>The avg.</returns>
        public int Avg()
        {
            return (Sum() / m_circularListArr.Length);
        }

        /// <summary>
        ///     Gets summary of circular list elements
        /// </summary>
        /// <returns>The sum.</returns>
        public int Sum()
        {
            int summary = 0;

            for (int i = 0; i < m_circularListArr.Length; i++)
            {
                summary += m_circularListArr[i];
            }
            return summary;
        }

        /// <summary>
        ///     Gets maximum value
        /// </summary>
        /// <returns>The max.</returns>
        public ArrayIndexInfo Max()
        {
            return GetMaximumValueWithIndex();
        }

        public void Print()
        {
            Console.WriteLine("");
            for (int i = 0; i < m_circularListArr.Length; i++)
            {
                Console.WriteLine("circularList[{0}] = {1}", i, this[i]);
            }
            Console.WriteLine("Summary: {0}", Sum());
            Console.WriteLine("Average: {0}", Avg());
            Console.WriteLine("Maximum: {0}", Max().Value);
            Console.WriteLine("Minimum: {0}", Min().Value);
            Console.WriteLine("Previous element before minimum: {0}", GetPrevious(Min()).Value);
            Console.WriteLine("");
        }

        /// <summary>
        ///     Clear this instance.
        /// </summary>
        public void Clear()
        {
            m_circularListArr = null;
            GC.Collect();

            m_circularListArr = new int[0];
        }

        /// <summary>
        ///     Gets the array sequence.
        /// </summary>
        /// <returns>The array sequence.</returns>
        /// <param name="sequence">Sequence.</param>
        public int GetArraySequence(int sequence)
        {
            int length = m_circularListArr.Length;
            int index = sequence - 1;
            int result = -1;

            if (length >= index)
            {
                result = m_circularListArr[index];
            }
            else Console.WriteLine("[ERROR]: Invalid index!");
            return result;
        }

        /// <summary>
        ///     Gets the previous before minimum.
        /// </summary>
        /// <returns>The previous before minimum.</returns>
        /// <param name="minimum">Minimum.</param>
        protected ArrayIndexInfo GetPreviousBeforeMinimum(ArrayIndexInfo minimum)
        {
            ArrayIndexInfo previous = new ArrayIndexInfo();
            if (minimum.Index > 0)
            {
                previous.Index = minimum.Index - 1;
                previous.Value = m_circularListArr[previous.Index];
            }
            else
            {
                previous.Index = m_circularListArr.Length - 1;
                previous.Value = m_circularListArr[previous.Index];
            }
            return previous;
        }

        /// <summary>
        ///     Gets the maximum index of the value with.
        /// </summary>
        /// <returns>The maximum value with index.</returns>
        protected ArrayIndexInfo GetMaximumValueWithIndex()
        {
            ArrayIndexInfo indexInfo = new ArrayIndexInfo();
            indexInfo.Index = -1;
            indexInfo.Value = m_circularListArr[0];

            for (int i = 0; i < m_circularListArr.Length; i++)
            {
                int value = m_circularListArr[i];
                if (value > indexInfo.Value)
                {
                    indexInfo.Index = i;
                    indexInfo.Value = value;
                }
            }
            return indexInfo;
        }

        /// <summary>
        ///     Gets the minimum index of the value with.
        /// </summary>
        /// <returns>The minimum value with index.</returns>
        protected ArrayIndexInfo GetMinimumValueWithIndex()
        {
            ArrayIndexInfo indexInfo = new ArrayIndexInfo();
            indexInfo.Index = -1;
            indexInfo.Value = m_circularListArr[0];

            for (int i = 0; i < m_circularListArr.Length; i++)
            {
                int value = m_circularListArr[i];
                if (value < indexInfo.Value)
                {
                    indexInfo.Index = i;
                    indexInfo.Value = value;
                }
            }
            return indexInfo;
        }
    }
}
