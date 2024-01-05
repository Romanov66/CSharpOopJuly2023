using System.Collections;
using System.Text;

namespace ArrayListTask
{
    public class CustomList<T> : IList<T>
    {
        private const int DefaultCapacity = 10;

        private T[] items;
        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public int Capacity
        {
            get => items.Length;
            set
            {
                if (value < Count)
                {
                    throw new ArgumentException($"Вместимость не должна быть меньше количества элементов в списке. Value = {value}; количество элементов = {Count}", nameof(value));
                }

                if (value == items.Length)
                {
                    return;
                }

                Array.Resize(ref items, value);
            }
        }

        public CustomList()
        {
            items = new T[DefaultCapacity];
        }

        public CustomList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"Вместимость списка не может быть меньше нуля. Capacity = {capacity}.");
            }

            items = new T[capacity];
        }

        public CustomList(T[] items)
        {
            this.items = new T[items.Length];
            Array.Copy(items, 0, this.items, 0, items.Length);

            Count = items.Length;
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return items[index];
            }

            set
            {
                CheckIndex(index);
                items[index] = value;

                modCount++;
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не должен быть меньше нуля и быть больше, либо равен количеству элементов списка. Количество элементов списка = {Count}. Индекс = {index}");
            }
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new();
            stringBuilder.Append('[');

            for (int i = 0; i < Count; i++)
            {
                stringBuilder
                    .Append(items[i])
                    .Append(", ");
            }

            return stringBuilder
                .Remove(stringBuilder.Length - 2, 2)
                .Append(']')
                .ToString();
        }

        public void Add(T item)
        {
            if (Count >= Capacity)
            {
                IncreaseCapacity();
            }

            items[Count] = item;

            Count++;
            modCount++;
        }

        private void IncreaseCapacity()
        {
            if (Capacity == 0)
            {
                Capacity = DefaultCapacity;
            }
            else
            {
                Capacity *= 2;
            }
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(items, 0, Count);

                Count = 0;
                modCount++;
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int startIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Массив не должен быть null");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Индекс не должен быть меньше нуля. Индекс = {startIndex}");
            }

            if (Count > array.Length - startIndex)
            {
                throw new ArgumentException($"Копирование невозможно. Длина массива с заданного индекса меньше, чем количество элементов списка. Длина массива с заданного индекса = {array.Length - startIndex}; количество элементов = {Count}.", nameof(array));
            }

            Array.Copy(items, 0, array, startIndex, Count);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            items[Count - 1] = default;

            Count--;
            modCount++;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, Count);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не должен быть меньше нуля и быть больше количества элементов списка. Количество элементов списка = {Count}. Индекс = {index}");
            }

            if (index == Count)
            {
                Add(item);

                return;
            }

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = item;

            Count++;
            modCount++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            for (int i = 0; i < Count; ++i)
            {
                if (initialModCount != modCount)
                {
                    throw new InvalidOperationException("Список изменился.");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void TrimExcess()
        {
            int occupancyPercent = (int)Math.Round((double)Count / Capacity * 100, MidpointRounding.AwayFromZero);

            if (occupancyPercent < 90)
            {
                Capacity = Count;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            CustomList<T> list = (CustomList<T>)obj;

            if (list.Count != Count)
            {
                return false;
            }

            for (int i = 0; i < Count; i++)
            {
                if (!Equals(items[i], list.items[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            for (int i = 0; i < Count; i++)
            {
                if (items[i] is null)
                {
                    hash *= prime;
                }
                else
                {
                    hash = hash * prime + items[i].GetHashCode();
                }
            }

            return hash;
        }
    }
}