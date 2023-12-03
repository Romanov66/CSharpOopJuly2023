using System.Text;

namespace ListTask
{
    public class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                ListItem<T> item = GetItem(index);

                return item.Data;
            }
            set
            {
                ListItem<T> item = GetItem(index);

                item.Data = value;
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не должен быть меньше нуля и больше, либо равен размеру списка. Размер списка = {Count}. Индекс = {index}");
            }
        }

        private void CheckList()
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head), "Список пуст.");
            }
        }

        private ListItem<T> GetItem(int index)
        {
            CheckIndex(index);

            ListItem<T> item = head;

            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item;
        }

        public T GetFirst()
        {
            CheckList();

            return head.Data;
        }

        public T RemoveFirst()
        {
            CheckList();

            T removedData = head.Data;
            head = head.Next;
            Count--;

            return removedData;
        }

        public T Set(int index, T data)
        {
            CheckIndex(index);

            T oldData = this[index];
            this[index] = data;

            return oldData;
        }

        public void AddFirst(T data)
        {
            ListItem<T> item = new(data, head);
            head = item;

            Count++;
        }

        public void Add(int index, T data)
        {
            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            CheckIndex(index);

            ListItem<T> previousItem = GetItem(index - 1);
            ListItem<T> item = new(data, previousItem.Next);
            previousItem.Next = item;

            Count++;
        }

        public T RemoveByIndex(int index)
        {
            CheckIndex(index);

            T removedData;

            if (index == 0)
            {
                return RemoveFirst();
            }

            ListItem<T> previousItem = GetItem(index - 1);
            ListItem<T> currentItem = previousItem.Next;

            removedData = currentItem.Data;
            previousItem.Next = currentItem.Next;

            Count--;

            return removedData;
        }

        public bool RemoveByData(T data)
        {
            for (ListItem<T> currentItem = head, previousItem = null; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
            {
                if (currentItem.Data.Equals(data))
                {
                    if (previousItem == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previousItem.Next = currentItem.Next;
                    }

                    Count--;

                    return true;
                }
            }

            Count--;

            return false;
        }

        public void Revert()
        {
            if (Count <= 1)
            {
                return;
            }

            for (ListItem<T> currentItem = head.Next, previousItem = head; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
            {
                previousItem.Next = currentItem.Next;
                currentItem.Next = head;
                head = currentItem;

                currentItem = previousItem;
            }
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> copyList = new SinglyLinkedList<T>();

            for (ListItem<T> item = head; copyList.Count < Count; item = item.Next)
            {
                ListItem<T> copyItem;

                if (item.Next != null)
                {
                    ListItem<T> copyNext = new(item.Next.Data);
                    copyItem = new(item.Data, copyNext);
                }
                else
                {
                    copyItem = new(item.Data);
                }

                if (copyList.Count == 0)
                {
                    copyList.head = copyItem;
                }

                copyList.Count++;
            }

            return copyList;
        }

        public override string ToString()
        {
            if (head == null)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('[');
            int i = 0;

            for (ListItem<T> currentItem = head; i < Count; currentItem = currentItem.Next)
            {
                stringBuilder
                    .Append(currentItem.Data)
                    .Append(", ");

                i++;
            }

            return stringBuilder
                .Remove(stringBuilder.Length - 2, 2)
                .Append(']')
                .ToString();
        }
    }
}