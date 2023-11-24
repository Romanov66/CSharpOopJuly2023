using System.Collections;
using System.Text;

namespace HashTableTask
{
    internal class HashTable<T> : ICollection<T>
    {
        private List<T>[] lists;
        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable()
        {
            lists = new List<T>[10];
        }

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), $"Размер не можеть быть меньше, либо равен 0. Текущее значение = {size}.");
            }

            lists = new List<T>[size];
        }

        public HashTable(ICollection<T> list)
        {
            if (list.Count == 0)
            {
                throw new ArgumentException("Передан пустой лист.", nameof(list));
            }

            if (list.Count <= 10)
            {
                lists = new List<T>[10];
            }
            else
            {
                lists = new List<T>[list.Count];
            }

            foreach (var e in list)
            {
                T element = e;
                Add(element);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    if (i == lists.Length - 1)
                    {
                        stringBuilder.Append($"[{string.Join(", ", lists[i])}]");
                    }
                    else
                    {
                        stringBuilder.Append($"[{string.Join(", ", lists[i])}]").Append(", ");
                    }
                }
            }

            return $"[{stringBuilder}]";
        }

        public void Add(T element)
        {
            if (element != null)
            {
                int index = Math.Abs(element.GetHashCode() % lists.Length);

                if (lists[index] is null)
                {
                    lists[index] = new List<T>();

                    Count++;
                }

                lists[index].Add(element);

                modCount++;
            }
        }

        public void Clear()
        {
            if (lists.Length == 0)
            {
                return;
            }

            Array.Clear(lists);

            Count = 0;
            modCount++;
        }

        public bool Contains(T element)
        {
            if (element == null)
            {
                return false;
            }

            int index = Math.Abs(element.GetHashCode() % lists.Length);

            if (lists[index] is null)
            {
                return false;
            }

            return lists[index].Contains(element);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Массив не может быть null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Индекс не должен быть меньше нуля. Индекс = {arrayIndex}.");
            }

            List<T> allData = new();

            for (int i = 0; i < lists.Length; i++)
            {
                for (int j = 0; j < lists[i].Count; j++)
                {
                    T element = lists[i][j];
                    allData.Add(element);
                }
            }

            if (allData.Count > array.Length - arrayIndex)
            {
                throw new ArgumentException($"Копирование невозможно. Длинна массива с заданного индекса меньше, чем количество компонентов. Длинна массива с заданного индекса = {array.Length - arrayIndex}; количество компонентов = {allData.Count}.", nameof(array));
            }

            Array.Copy(allData.ToArray(), 0, array, arrayIndex, allData.Count);
        }

        public bool Remove(T element)
        {
            if (element == null)
            {
                return false;
            }

            int index = Math.Abs(element.GetHashCode() % lists.Length);

            if (lists[index] is null)
            {
                return false;
            }

            if (lists[index].Remove(element))
            {
                if (lists[index].Count == 0)
                {
                    Count--;
                }

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int startModCount = modCount;

            for (int i = 0; i < lists.Length; ++i)
            {
                if (startModCount != modCount)
                {
                    throw new InvalidOperationException("Недопускается изменять список.");
                }

                foreach (T element in lists[i])
                {
                    yield return element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}