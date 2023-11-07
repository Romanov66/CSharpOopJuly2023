namespace TreeTask
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public T Data { get; set; }

        public TreeNode(T value)
        {
            Left = null;
            Right = null;
            Data = value;
        }
    }
}
