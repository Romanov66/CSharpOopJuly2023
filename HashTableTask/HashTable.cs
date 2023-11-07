using System.Collections;
using System.Text;

namespace HashTableTask
{
    internal class HashTable<T> : ICollection<T>
    {
        public ICollection<T>[] listsArray;
        private int count;
        private int modCount;

        public HashTable(int size)
        {
            listsArray = new ICollection<T>[size];
        }

        public HashTable(ICollection<T>[] listsArray)
        {
            this.listsArray = listsArray;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public int Capacity
        {
            get
            {
                return listsArray.Length;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual string ToString()
        {
            StringBuilder listsInfo = new StringBuilder();

            foreach (ICollection<T> e in listsArray)
            {
                if (e is null)
                {
                    continue;
                }
                else
                {
                    listsInfo.Append(string.Join(", ", e)).Append("    ");
                }
            }

            return listsInfo.ToString();
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Переданнный аргумен не может быть null", nameof(element));
            }

            int index = Math.Abs(element.GetHashCode() % listsArray.Length);

            if (listsArray[index] is null)
            {
                listsArray[index] = new List<T>();
            }

            listsArray[index].Add(element);

            count++;
            modCount++;
        }

        public void Add(ICollection<T> item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Переданнный аргумен не может быть null", nameof(item));
            }

            listsArray[count] = item;

            count++;
            modCount++;
        }

        public void Clear()
        {
            Array.Clear(listsArray, 0, listsArray.Length);

            count = 0;
            modCount++;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                return false;
            }

            bool isContains = false;

            int index = Math.Abs(item.GetHashCode() % listsArray.Length);

            if (listsArray[index] is null)
            {
                return false;
            }

            foreach (T e in listsArray[index])
            {
                if (e is not null)
                {
                    if (e.Equals(item))
                    {
                        isContains = true;

                        break;
                    }
                }
            }

            return isContains;
        }

        public void CopyTo(T[] array, int listsArrayIndex)
        {
            Array.Copy(listsArray[listsArrayIndex].ToArray(), 0, array, 0, listsArray[listsArrayIndex].Count);
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                return false;
            }

            bool isDelete = false;

            int index = Math.Abs(item.GetHashCode() % listsArray.Length);

            if (listsArray[index] is null)
            {
                return false;
            }

            foreach (T e in listsArray[index])
            {
                if (e is not null)
                {
                    if (e.Equals(item))
                    {
                        listsArray[index].Remove(e);

                        if (listsArray[index].Count == 0)
                        {
                            count--;
                        }

                        isDelete = true;
                        modCount++;

                        break;
                    }
                }
            }

            return isDelete;
        }

        public IEnumerator<ICollection<T>> GetEnumerator()
        {
            int currentModCount = modCount;

            for (int i = 0; i < Count; ++i)
            {
                if (currentModCount != modCount)
                {
                    throw new InvalidOperationException("Недопускается изменять список.");
                }

                yield return listsArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}