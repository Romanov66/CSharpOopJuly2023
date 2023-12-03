using System.Collections;
using System.Text;

namespace HashTableTask
{
    internal class HashTable<T> : ICollection<T>
    {
        private List<T>?[] lists;
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
                throw new ArgumentOutOfRangeException(nameof(size), $"Размер не может быть меньше, либо равен 0. Текущее значение = {size}.");
            }

            lists = new List<T>[size];
        }

        public HashTable(ICollection<T> collection)
        {
            if (collection.Count <= 10)
            {
                lists = new List<T>[10];
            }
            else
            {
                lists = new List<T>[collection.Count];
            }

            foreach (T e in collection)
            {
                Add(e);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append('[');

            for (int i = 0; i < lists.Length; i++)
            {
                List<T>? elements = lists[i];

                if (elements is null)
                {
                    stringBuilder.Append("[]");
                }
                else
                {
                    stringBuilder
                    .Append('[')
                    .Append(string.Join(", ", elements))
                    .Append(']')
                    .Append(", ");
                }
            }

            return stringBuilder
                .Remove(stringBuilder.Length - 2, 2)
                .Append(']')
                .ToString();
        }

        private int GetIndex(T element)
        {
            if (element == null)
            {
                return -1;
            }

            return Math.Abs(element.GetHashCode() % lists.Length);
        }

        public void Add(T element)
        {
            int index = GetIndex(element);

            if (index < 0)
            {
                return;
            }

            if (lists[index] is null)
            {
                lists[index] = new List<T>();
            }

            lists[index]?.Add(element);

            Count++;
            modCount++;
        }

        public void Clear()
        {
            Array.Clear(lists);

            Count = 0;
            modCount++;
        }

        public bool Contains(T element)
        {
            int index = GetIndex(element);

            if (index < 0)
            {
                return false;
            }

            List<T>? elements = lists[index];

            return elements != null ? elements.Contains(element) : false;
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

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException($"Копирование невозможно. Длинна массива с заданного индекса меньше, чем количество компонентов. Длинна массива с заданного индекса = {array.Length - arrayIndex}; количество компонентов = {Count}.", nameof(array));
            }

            for (int i = 0; i < lists.Length; i++)
            {
                List<T>? elements = lists[i];

                if (elements != null)
                {
                    Array.Copy(elements.ToArray(), 0, array, arrayIndex, elements.Count);

                    arrayIndex += elements.Count;
                }
            }
        }

        public bool Remove(T element)
        {
            int index = GetIndex(element);

            if (index < 0)
            {
                return false;
            }

            List<T>? elements = lists[index];

            bool isRemoved = elements != null ? elements.Remove(element) : false;

            if (isRemoved)
            {
                Count--;
                modCount++;
            }

            return isRemoved;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            foreach (List<T>? elements in lists)
            {
                if (elements != null)
                {
                    foreach (T element in elements)
                    {
                        if (initialModCount != modCount)
                        {
                            throw new InvalidOperationException("Список изменен.");
                        }

                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}