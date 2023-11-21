using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class SingleLinkedList
    {

        /*public void Add(ListItem<T> item)
        {
            if (Count == 0)
            {
                head = item;

                Count++;

                return;
            }

            for (ListItem<T> currentItem = head; currentItem != null; currentItem = currentItem.Next)
            {
                if (currentItem.Next == null)
                {
                    currentItem.Next = item;

                    Count++;

                    return;
                }
            }
        }*/

        /*int indexCurrentElement = 0;

for (ListItem<T>? currentItem = head, previousItem = null; indexCurrentElement <= index; previousItem = currentItem, currentItem = currentItem.Next)
{
    if (indexCurrentElement == index)
    {
        deletedData = currentItem.Data;
        previousItem.Next = currentItem.Next;

        Count--;
    }

    indexCurrentElement++;
}*/

        /*public T? GetData(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException("Индекс не может быть больше, чем количество элементов в списке.");
            }

            if (head == null)
            {
                return default;
            }

            ListItem<T> currentItem = head;
            T? elementValue = default;

            for (int i = 0; i <= index; i++)
            {
                if (currentItem == null || currentItem.Next == null)
                {
                    return elementValue;
                }

                if (i == index)
                {
                    elementValue = currentItem.Data;
                }
                else
                {
                    currentItem = currentItem.Next;
                }
            }

            return elementValue;
        }*/
    }
}
