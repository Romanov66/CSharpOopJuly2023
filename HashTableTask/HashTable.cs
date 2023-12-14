﻿using System.Collections;
using System.Text;

namespace HashTableTask
{
    internal class HashTable<T> : ICollection<T>
    {
        public bool IsReadOnly => false;

        private List<T>?[] lists;
        private int modCount;

        public int Count { get; private set; }

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

            foreach (List<T>? elements in lists)
            {
                if (elements is null)
                {
                    stringBuilder.Append("null, ");
                }
                else
                {
                    stringBuilder
                    .Append('[')
                    .Append(string.Join(", ", elements))
                    .Append("], ");
                }
            }

            return stringBuilder
                .Remove(stringBuilder.Length - 2, 2)
                .Append(']')
                .ToString();
        }

        private int GetIndex(T element)
        {
            if (element is null)
            {
                return 0;
            }

            return Math.Abs(element.GetHashCode() % lists.Length);
        }

        public void Add(T element)
        {
            int index = GetIndex(element);

            if (lists[index] is null)
            {
                lists[index] = new List<T>();
            }

            lists[index]!.Add(element);

            Count++;
            modCount++;
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(lists);

                Count = 0;
                modCount++;
            }
        }

        public bool Contains(T element)
        {
            int index = GetIndex(element);

            return lists[index] != null && lists[index]!.Contains(element);
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
                throw new ArgumentException($"Копирование невозможно. Длина массива с заданного индекса меньше, чем количество компонентов. Длина массива с заданного индекса = {array.Length - arrayIndex}; количество компонентов = {Count}.", nameof(array));
            }

            int startIndex = arrayIndex;

            foreach (List<T>? elements in lists)
            {
                if (elements is not null)
                {
                    elements.CopyTo(array, startIndex);

                    startIndex += elements.Count;
                }
            }
        }

        public bool Remove(T element)
        {
            int index = GetIndex(element);

            if (lists[index] != null && lists[index]!.Remove(element))
            {
                Count--;
                modCount++;

                return true;
            }

            return false;
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