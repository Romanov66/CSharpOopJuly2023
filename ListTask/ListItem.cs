namespace ListTask
{
    public class ListItem<T>
    {
        public ListItem(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public ListItem<T> Next { get; set; }
    }
}
