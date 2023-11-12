using System.Collections;

namespace ArrayListTask
{
    public class CustomList<T> : IList<T>
    {
        private T[] items;
        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly { get => false; }

        public int Capacity
        {
            get => items.Length;
            set
            {
                if (value < Count)
                {
                    throw new ArgumentException($"Значение не может быть меньше количества элементов в списке. Value = {value}.", nameof(value));
                }

                if (value == items.Length)
                {
                    return;
                }

                if (value > 0)
                {
                    if (Count > 0)
                    {
                        Array.Resize(ref items, value);
                    }
                }
                else
                {
                    items = Array.Empty<T>();
                }
            }
        }

        public CustomList()
        {
            items = Array.Empty<T>();
        }

        public CustomList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"Размер массива не может быть меньше нуля. Capacity = {capacity}.");
            }

            if (capacity == 0)
            {
                items = Array.Empty<T>();
            }
            else
            {
                items = new T[capacity];
            }
        }

        public CustomList(T[] inputItems)
        {
            items = inputItems;
            Count = items.Length;
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не может быть больше, чем количество элементов в списке. Количество элементов = {Count}. Переданное значение индекса = {index}");
                }

                return items[index];
            }

            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не может быть больше, чем количество элементов в списке. Количество элементов = {Count}. Переданное значение индекса = {index}");
                }

                items[index] = value;
            }
        }

        public override string ToString()
        {
            return "[ " + string.Join(", ", items.Where(i => i != null)) + " ]";
        }

        public void Add(T item)
        {
            if (Count >= items.Length)
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
                Array.Resize(ref items, 10);
            }

            Array.Resize(ref items, items.Length * 2);
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
            var index = Array.IndexOf(items, item);

            if (index >= 0)
            {
                return true;
            }

            return false;
        }

        public void CopyTo(T[] inputItems, int startIndex)
        {
            if (inputItems is null)
            {
                throw new ArgumentNullException(nameof(inputItems), "Массив не может быть null");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), $"Индекс не должен быть меньше нуля. Индекс = {startIndex}");
            }

            if (Count > inputItems.Length)
            {
                throw new ArgumentException("Количество элементов исходного списка больше, чем конечный индекс массива", nameof(inputItems));
            }

            Array.Copy(items, startIndex, inputItems, 0, Count - startIndex);
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(items, item);

            if (index >= 0)
            {
                RemoveAt(index);

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Переданный индекс превышает количество элементов в списке. Количество элементов = {Count}. Переданное значение индекса = {index}");
            }

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
            return Array.IndexOf(items, item);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Некорректное значение индекса. Индекс = {index}");
            }

            if (Capacity == Count)
            {
                Capacity = Capacity + 1;
            }

            if (index == Capacity - 1)
            {
                Add(item);

                return;
            }

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
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int startModCount = modCount;

            for (int i = 0; i < Count; ++i)
            {
                if (startModCount != modCount)
                {
                    throw new InvalidOperationException("Спиок изменился.");
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
            int occupancyPercent = Count / Capacity * 100;

            if (occupancyPercent < 90)
            {
                Capacity = Count;
            }
        }

        public override bool Equals(object? obj)
        {
            if(ReferenceEquals(obj, this))
            {
                return true;
            }

            if(ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }

            CustomList<T> list = (CustomList<T>) obj;
            
            if(list.Capacity != Capacity)
            {
                return false;
            }

            if(list.Count !=  Count)
            {
                return false;
            }

            for (int i = 0; i < Capacity; ++i)
            {
                if (!items[i].Equals(list.items[i]))
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
            hash = prime * hash + Capacity;
            hash = prime * hash + Count;
            hash = prime * hash + (items != null ? items.GetHashCode() : 0);

            return hash;
        }
    }
}