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

        private void CheckIndexToAdd(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не должен быть меньше нуля и больше размера списка. Размер списка = {Count}. Индекс = {index}");
            }
        }

        private void CheckIndexToAccess(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не должен быть меньше нуля и больше, либо равен размеру списка. Размер списка = {Count}. Индекс = {index}");
            }
        }

        private void CheckListToNull()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Список пуст.");
            }
        }

        private ListItem<T> GetItem(int index)
        {
            CheckIndexToAccess(index);

            ListItem<T> item = head;

            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item;
        }

        public T GetFirst()
        {
            CheckListToNull();

            return head.Data;
        }

        public T RemoveFirst()
        {
            CheckListToNull();

            T removedData = head.Data;
            head = head.Next;
            Count--;

            return removedData;
        }

        public T Set(int index, T data)
        {
            CheckIndexToAccess(index);

            T oldData = this[index];
            this[index] = data;

            return oldData;
        }

        public void AddFirst(T data)
        {
            head = new(data, head);

            Count++;
        }

        public void Add(int index, T data)
        {
            CheckIndexToAdd(index);

            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            ListItem<T> previousItem = GetItem(index - 1);
            previousItem.Next = new(data, previousItem.Next);

            Count++;
        }

        public T RemoveByIndex(int index)
        {
            CheckIndexToAccess(index);

            if (index == 0)
            {
                return RemoveFirst();
            }

            ListItem<T> previousItem = GetItem(index - 1);
            ListItem<T> currentItem = previousItem.Next;

            T removedData = currentItem.Data;
            previousItem.Next = currentItem.Next;

            Count--;

            return removedData;
        }

        public bool RemoveByData(T data)
        {
            for (ListItem<T> currentItem = head, previousItem = null; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
            {
                if (Equals(currentItem.Data, data))
                {
                    previousItem.Next = currentItem.Next;
                    Count--;

                    return true;
                }
            }

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

            for (ListItem<T> item = head; item != null; item = item.Next)
            {
                copyList.Add(copyList.Count, item.Data);
            }

            return copyList;
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('[');

            for (ListItem<T> currentItem = head; currentItem != null; currentItem = currentItem.Next)
            {
                stringBuilder
                    .Append(currentItem.Data)
                    .Append(", ");
            }

            return stringBuilder
                .Remove(stringBuilder.Length - 2, 2)
                .Append(']')
                .ToString();
        }
    }
}