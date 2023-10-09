using System.Collections;

namespace ArrayListTask
{
    public class MyList<T> : List<T>, IEnumerable
    {
        private T[] items;
        private int count;
        private bool readOnly;
        private int modCount;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool ReadOnly
        {
            get
            {
                readOnly = false;

                return readOnly;
            }
        }

        public int Capacity
        {
            get
            {
                return items.Length;
            }

            set
            {
                if (value < count)
                {
                    throw new ArgumentException("Значение не может быть меньше количества элементов в списке.");
                }

                if (value != items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];

                        if (count > 0)
                        {
                            Array.Copy(items, newItems, count);
                        }

                        items = newItems;

                        modCount++;
                    }
                    else
                    {
                        items = Array.Empty<T>();

                        modCount++;
                    }
                }
            }
        }

        public MyList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Размер массива не может быть меньше нуля");
            }
            else if (capacity == 0)
            {
                items = Array.Empty<T>();
            }
            else
            {
                items = new T[capacity];
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException("Индекс не может быть больше, чем количество элементов в списке.");
                }

                return items[index];
            }

            set
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException("Индекс не может быть больше, чем количество элементов в списке.");
                }

                items[index] = value;
            }
        }

        public virtual string ToString()
        {
            return string.Join(", ", items);
        }

        public void Add(T item)
        {
            if (count >= items.Length)
            {
                IncreaceCapacity();
            }

            items[count] = item;

            count++;
            modCount++;
        }

        private void IncreaceCapacity()
        {
            Array.Resize(ref items, items.Length * 2);
        }

        public void Clear()
        {
            if (count > 0)
            {
                Array.Clear(items, 0, count);

                count = 0;
            }
        }

        public bool Contains(T item)
        {
            bool isContains = false;

            if (item is null)
            {
                throw new NullReferenceException("Переданный аргумент не может быть null.");
            }

            for (int i = 0; i < count; i++)
            {
                if (items[i] is not null)
                {
                    if (items[i].Equals(item))
                    {
                        isContains = true;

                        break;
                    }
                }
            }

            return isContains;
        }

        public void CopyTo(T[] inputItems, int startIndex)
        {
            T[] newItems = new T[inputItems.Length];

            for (int i = startIndex; i < inputItems.Length; i++)
            {
                newItems[i] = inputItems[i];

                count++;
            }

            items = newItems;
        }

        public bool Remove(T item)
        {
            if (item is null)
            {
                return false;
            }

            bool isDelete = false;

            for (int i = 0; i < count; i++)
            {
                if (items[i] is not null)
                {
                    if (items[i].Equals(item))
                    {
                        Array.Copy(items, i + 1, items, i, count - i - 1);

                        isDelete = true;
                        items[count - 1] = default;

                        count--;
                        modCount++;

                        break;
                    }
                }
            }

            return isDelete;
        }

        public void RemoveAt(int index)
        {
            if (index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Переданный индекс превышает количество элементов в списке.");
            }

            if (index < count - 1)
            {
                Array.Copy(items, index + 1, items, index, count - index - 1);
            }

            items[count - 1] = default;

            count--;
            modCount++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = modCount;

            for (int i = 0; i < count; ++i)
            {
                if (currentModCount != modCount)
                {
                    throw new InvalidOperationException("Недопускается изменять список.");
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
            const int precentRemove = 10;
            int occupancyPercent = count / Capacity * 100;

            if (occupancyPercent <= precentRemove)
            {
                Capacity = count;
            }
        }
    }
}