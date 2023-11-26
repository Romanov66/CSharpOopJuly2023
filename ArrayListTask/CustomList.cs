using System.Collections;
using System.Text;

namespace ArrayListTask
{
    public class CustomList<T> : IList<T>
    {
        private T[] items;
        private const int defaultSize = 10;
        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public int Capacity
        {
            get => items.Length;
            set
            {
                if (value < 0 || value < Count)
                {
                    throw new ArgumentException($"Значение не должно быть меньше 0 и количества элементов в списке. Value = {value}; количество элементов = {Count}", nameof(value));
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
            items = new T[defaultSize];
        }

        public CustomList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"Размер списка не может быть меньше нуля. Capacity = {capacity}.");
            }

            items = new T[capacity];
        }

        public CustomList(T[] items)
        {
            if (items.Length == 0)
            {
                throw new ArgumentException($"Массив не должен быть пустым.", nameof(items));
            }

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
            }
        }

        private bool CheckIndex(int index)
        {
            if (index < 0 || index >= Capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не должен быть меньше нуля и больше, либо равен размеру списка. Размер списка = {Capacity}. Индекс = {index}");
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('[');

            for (int i = 0; i < Count; i++)
            {
                if (i == Count - 1)
                {
                    stringBuilder.Append($"{items[i]}");
                }
                else
                {
                    stringBuilder.Append($"{items[i]}, ");
                }
            }

            return stringBuilder.Append(']').ToString();
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
                items = new T[defaultSize];
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
            if (Count == 0)
            {
                return false;
            }

            return Array.IndexOf(items, item, 0, Count) > -1;
        }

        public void CopyTo(T[] items, int startIndex)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items), "Массив не должен быть null");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Индекс не должен быть меньше нуля. Индекс = {startIndex}");
            }

            if (Count > items.Length - startIndex)
            {
                throw new ArgumentException($"Копирование невозможно. Длинна массива с заданного индекса меньше, чем количество элементов списка. Длинна массива с заданного индекса = {items.Length - startIndex}; количество элементов = {Count}.", nameof(items));
            }

            Array.Copy(this.items, 0, items, startIndex, Count);
        }

        public bool Remove(T item)
        {
            try
            {
                RemoveAt(Array.IndexOf(items, item, 0, Count));
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

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
            CheckIndex(index);

            if (Count >= Capacity)
            {
                IncreaseCapacity();
            }

            for (int i = Count - 1; i > index - 1; i--)
            {
                items[i] = items[i + 1];
            }

            items[index] = item;
            /*
            T outerTemp = items[index];

            for (int i = index; i < Capacity; i++)
            {
                if (i == index)
                {
                    items[i] = item;
                    continue;
                }

                T innerTemp = items[i];
                items[i] = outerTemp;
                outerTemp = innerTemp;
            }*/
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
                if (items[i] is not null)
                {
                    if (!items[i].Equals(list.items[i]))
                    {
                        return false;
                    }
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
                hash = prime * hash + items[i].GetHashCode();
            }

            return hash;
        }
    }
}