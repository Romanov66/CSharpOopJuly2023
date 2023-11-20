using System.Text;

namespace ListTask
{
    public class SinglyLinkedList<T>
    {
        private ListItem<T>? head;

        public int Count { get; private set; }

        public T? this[int index]
        {
            get
            {
                ListItem<T>? item = GetItem(index);

                if (item == null)
                {
                    return default;
                }

                return item.Data;
            }
            set
            {
                ListItem<T>? item = GetItem(index);

                if (item != null)
                {
                    item.Data = value;
                }

            }
        }

        private ListItem<T>? GetItem(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Некорректное значение индекса. Индекс должен быть больше 0 и меньше количества элементов списка." +
                    $" Текущее значение индекса = {index}");
            }

            if (head == null)
            {
                return default;
            }

            ListItem<T> item = head;

            for (int i = 0; i < index; i++)
            {
                if (item.Next == null)
                {
                    return default;
                }

                item = item.Next;
            }

            return item;
        }

        public int GetIndex(T data)
        {
            if (Count == 0)
            {
                return -1;
            }

            int index = -1;
            int i = 0;

            for (ListItem<T>? currentItem = head; i < Count; currentItem = currentItem?.Next)
            {
                if (data != null && currentItem != null)
                {
                    if (data.Equals(currentItem.Data))
                    {
                        index = i;

                        break;
                    }
                }

                i++;
            }

            return index;
        }

        public T? GetFirst()
        {
            if (head == null)
            {
                return default;
            }

            return head.Data;
        }

        public T? Set(int index, T data)
        {
            T? oldData = this[index];
            this[index] = data;

            return oldData;
        }

        public void AddFirst(T data)
        {
            ListItem<T> item = new(data)
            {
                Next = head
            };

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

            ListItem<T>? previousItem = GetItem(index - 1);

            if (previousItem == null)
            {
                return;
            }

            ListItem<T> item = new(data);
            ListItem<T>? currentItem = GetItem(index);

            item.Next = currentItem;
            previousItem.Next = item;

            Count++;
        }

        public T? RemoveFirst()
        {
            if (head == null)
            {
                return default;
            }

            T? deletedData = head.Data;
            head = head.Next;
            Count--;

            return deletedData;
        }

        public T? RemoveByIndex(int index)
        {
            T? deletedData;

            if (index == 0)
            {
                if (head == null)
                {
                    return default;
                }

                deletedData = head.Data;
                head = head.Next;
            }
            else
            {
                ListItem<T>? previousItem = GetItem(index - 1);
                ListItem<T>? currentItem = GetItem(index);

                if (previousItem == null || currentItem == null)
                {
                    return default;
                }

                deletedData = currentItem.Data;
                previousItem.Next = currentItem.Next;
            }

            Count--;

            return deletedData;
        }

        public bool RemoveByData(T data)
        {
            int index = GetIndex(data);

            if (index < 0)
            {
                return false;
            }

            bool isDeleted = false;

            if (index == 0)
            {
                if (head == null)
                {
                    return isDeleted;
                }

                isDeleted = true;
                head = head.Next;
            }
            else
            {
                ListItem<T>? previousItem = GetItem(index - 1);
                ListItem<T>? currentItem = GetItem(index);

                if (previousItem == null || currentItem == null)
                {
                    return isDeleted;
                }

                previousItem.Next = currentItem.Next;
            }

            Count--;

            return isDeleted;
        }

        public void Revert()
        {
            if (Count == 0 || Count == 1)
            {
                return;
            }

            for (ListItem<T>? currentItem = head?.Next, previousItem = head; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
            {
                if (previousItem != null)
                {
                    previousItem.Next = currentItem.Next;
                    currentItem.Next = head;
                    head = currentItem;

                    currentItem = previousItem;
                }
            }
        }

        public SinglyLinkedList<T> Copy()
        {
            SinglyLinkedList<T> newList = new SinglyLinkedList<T>();
            int i = 0;

            for (ListItem<T>? currentItem = head, newListCurrentItem = null; i < Count; currentItem = currentItem?.Next, newListCurrentItem = newListCurrentItem?.Next)
            {
                if (currentItem != null)
                {
                    newListCurrentItem = new(currentItem.Data, currentItem.Next);

                    if (newListCurrentItem.Data != null)
                    {
                        newList.Add(i, newListCurrentItem.Data);
                    }
                }

                i++;
            }

            return newList;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;

            for (ListItem<T>? currentItem = head; i < Count; currentItem = currentItem?.Next)
            {
                if (currentItem == null)
                {
                    break;
                }

                if (i == Count - 1)
                {
                    stringBuilder.Append(currentItem.Data);
                }
                else
                {

                    stringBuilder.Append(currentItem.Data + ", ");
                }

                i++;
            }

            return "[ " + stringBuilder.ToString() + " ]";
        }
    }
}