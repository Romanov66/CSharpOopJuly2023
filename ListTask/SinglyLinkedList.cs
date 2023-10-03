using System.Text;

namespace ListTask
{
    internal class SinglyLinkedList<T>
    {
        private ListItem<T> head;
        private int count;

        public int GetLength()
        {
            return count;
        }

        public T GetFirstElementValue()
        {
            return head.Data;
        }

        public T GetElementValue(int index)
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException("Индекс не может быть больше, чем количество элементов в списке.");
            }

            ListItem<T> currentItem = head;
            T elementValue = default;

            for (int i = 0; i <= index; i++)
            {
                if (i == index)
                {
                    elementValue = currentItem.Data;
                }

                currentItem = currentItem.Next;
            }

            return elementValue;
        }

        public T SetValue(int index, T value)
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException("Индекс не может быть больше, чем количество элементов в списке.");
            }

            ListItem<T> currentItem = head;
            T previousElementValue = default;

            for (int i = 0; i <= index; i++)
            {
                if (i == index)
                {
                    previousElementValue = currentItem.Data;
                    currentItem.Data = value;
                }

                currentItem = currentItem.Next;
            }

            return previousElementValue;
        }

        public T RemoveValue(int inputIndex)
        {
            if (inputIndex >= count)
            {
                throw new IndexOutOfRangeException("Индекс не может быть больше, чем количество элементов в списке.");
            }

            T elementValue = default;
            int indexCurrentElement = 0;

            for (ListItem<T> currentItem = head, previousItem = null; indexCurrentElement <= inputIndex; previousItem = currentItem, currentItem = currentItem.Next)
            {
                if (indexCurrentElement == inputIndex)
                {
                    elementValue = currentItem.Data;
                    previousItem.Next = currentItem.Next;

                    count--;
                }

                indexCurrentElement++;
            }

            return elementValue;
        }

        public void AddStart(ListItem<T> item)
        {
            item.Next = head;
            head = item;

            count++;
        }

        public void Add(ListItem<T> item)
        {
            if (count == 0)
            {
                head = item;

                count++;

                return;
            }

            for (ListItem<T> currentItem = head; currentItem != null; currentItem = currentItem.Next)
            {
                if (currentItem.Next == null)
                {
                    currentItem.Next = item;

                    count++;

                    return;
                }
            }
        }

        public void Add(ListItem<T> item, int inputIndex)
        {
            if (inputIndex >= count)
            {
                throw new IndexOutOfRangeException("Индекс не может быть больше, чем количество элементов в списке.");
            }

            int indexCurrentElement = 0;

            for (ListItem<T> currentItem = head, previousItem = null; indexCurrentElement <= inputIndex; previousItem = currentItem, currentItem = currentItem.Next)
            {
                if (indexCurrentElement == inputIndex)
                {
                    item.Next = currentItem;
                    previousItem.Next = item;

                    count++;
                }

                indexCurrentElement++;
            }
        }

        public bool RemoveElement(T elementValue)
        {
            if (ReferenceEquals(elementValue, null))
            {
                return false;
            }

            bool isDeleted = false;

            for (ListItem<T> currentItem = head, previousItem = null; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
            {
                if (elementValue.Equals(currentItem.Data))
                {
                    previousItem.Next = currentItem.Next;
                    isDeleted = true;

                    count--;

                    break;
                }
            }

            return isDeleted;
        }

        public T RemoveStart()
        {
            T firstElementValue = head.Data;
            head = head.Next;

            count--;

            return firstElementValue;
        }

        public void RevertList()
        {
            for (ListItem<T> currentItem = head.Next, previousItem = head; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
            {
                previousItem.Next = currentItem.Next;
                currentItem.Next = head;
                head = currentItem;

                currentItem = previousItem;
            }
        }

        public SinglyLinkedList<T> CopyList()
        {
            SinglyLinkedList<T> newList = new SinglyLinkedList<T>();

            for (ListItem<T> currentItem = head, currentItemNewList = newList.head; currentItem != null; currentItem = currentItem.Next, currentItemNewList = currentItemNewList.Next)
            {
                if (currentItemNewList is null)
                {
                    newList.head = head;
                    currentItemNewList = head;
                }
            }

            newList.count = count;

            return newList;
        }

        public virtual string ToString()
        {
            StringBuilder itemsData = new StringBuilder();

            for (ListItem<T> currentItem = head; currentItem != null; currentItem = currentItem.Next)
            {
                itemsData.Append($"{currentItem.Data} ");
            }

            string itemsDataRow = itemsData.ToString();

            return itemsDataRow;
        }
    }
}