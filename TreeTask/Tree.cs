namespace TreeTask
{
    public class BinaryTree<T>
    {
        private TreeNode<T> root;
        private IComparer<T> comparator;

        public int Count { get; private set; }

        public BinaryTree()
        {
        }

        public BinaryTree(IComparer<T> comparator)
        {
            this.comparator = comparator;
        }

        private int Compare(T data1, T data2)
        {
            if (data1 is null)
            {
                throw new ArgumentException("Параметр не может быть null", nameof(data1));
            }

            if (data2 is null)
            {
                throw new ArgumentException("Параметр не может быть null", nameof(data2));
            }

            if (comparator is null)
            {
                IComparable<T> comparable = (IComparable<T>)data1;

                return comparable.CompareTo(data2);
            }

            return comparator.Compare(data1, data2);
        }

        public void Add(T data)
        {
            if (root == null)
            {
                root = new TreeNode<T>(data);
                Count++;

                return;
            }

            TreeNode<T> currentNode = root;
            TreeNode<T> node = new TreeNode<T>(data);

            while (currentNode is not null)
            {
                int comparisonResult = Compare(currentNode.Data, node.Data);

                if (comparisonResult > 0)
                {
                    if (currentNode.Left is null)
                    {
                        currentNode.Left = node;
                        Count++;

                        return;
                    }

                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right is null)
                    {
                        currentNode.Right = node;
                        Count++;

                        return;
                    }

                    currentNode = currentNode.Right;
                }
            }
        }

        public bool Contains(T data)
        {
            TreeNode<T> currentNode = root;

            while (currentNode is not null)
            {
                int comparisonResult = Compare(currentNode.Data, data);

                if (comparisonResult == 0)
                {
                    return true;
                }

                if (comparisonResult > 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return false;
        }

        public bool Remove(T data)
        {
            if (data == null)
            {
                return false;
            }

            if (root is null)
            {
                return false;
            }

            TreeNode<T> deletedNodeParent = default;
            TreeNode<T> deletedNode = root;
            int comparisonResult = -1;
            int i = 0;

            while (deletedNode is not null)
            {
                comparisonResult = Compare(deletedNode.Data, data);

                if (comparisonResult == 0)
                {
                    break;
                }

                if (comparisonResult > 0)
                {
                    deletedNodeParent = deletedNode;
                    deletedNode = deletedNodeParent.Left;
                }
                else
                {
                    deletedNodeParent = deletedNode;
                    deletedNode = deletedNodeParent.Right;
                }

                i++;
            }

            if (comparisonResult != 0)
            {
                return false;
            }

            if (i == 0)
            {
                if (deletedNode.Left is null && deletedNode.Right is null)
                {
                    root = null;
                }
                else if (deletedNode.Left is null || deletedNode.Right is null)
                {
                    if (deletedNode.Left is null)
                    {
                        root = deletedNode.Right;
                    }
                    else
                    {
                        root = deletedNode.Left;
                    }
                }
                else
                {
                    TreeNode<T> minLeftNodeParent = deletedNode.Right;
                    TreeNode<T> minLeftNode = minLeftNodeParent.Left;

                    if (minLeftNode is null)
                    {
                        minLeftNodeParent.Left = root.Left;
                        minLeftNodeParent.Right = root.Right;

                        root = minLeftNodeParent;
                        Count--;

                        return true;
                    }

                    while (minLeftNode.Left is not null)
                    {
                        minLeftNodeParent = minLeftNode;
                        minLeftNode = minLeftNodeParent.Left;
                    }

                    if (minLeftNode.Right is not null)
                    {
                        minLeftNodeParent.Left = minLeftNode.Right;
                    }
                    else
                    {
                        minLeftNodeParent.Left = null;
                    }

                    minLeftNode.Left = root.Left;
                    minLeftNode.Right = root.Right;

                    root = minLeftNode;
                }
            }
            else
            {
                if (deletedNode.Left is null && deletedNode.Right is null)
                {
                    if (deletedNode == deletedNodeParent.Left)
                    {
                        deletedNodeParent.Left = null;
                    }
                    else
                    {
                        deletedNodeParent.Right = null;
                    }
                }
                else if (deletedNode.Left is null || deletedNode.Right is null)
                {
                    if (deletedNode.Left is null)
                    {
                        if (deletedNode == deletedNodeParent.Left)
                        {
                            deletedNodeParent.Left = deletedNode.Right;
                        }
                        else
                        {
                            deletedNodeParent.Right = deletedNode.Right;
                        }
                    }
                    else
                    {
                        if (deletedNode == deletedNodeParent.Left)
                        {
                            deletedNodeParent.Left = deletedNode.Left;
                        }
                        else
                        {
                            deletedNodeParent.Right = deletedNode.Left;
                        }
                    }
                }
                else
                {
                    TreeNode<T> minLeftNodeParent = deletedNode.Right;
                    TreeNode<T> minLeftNode = minLeftNodeParent.Left;

                    if (minLeftNode is null)
                    {
                        minLeftNodeParent.Left = deletedNode.Left;

                        if (deletedNode == deletedNodeParent.Left)
                        {
                            deletedNodeParent.Left = minLeftNodeParent;
                        }
                        else
                        {
                            deletedNodeParent.Right = minLeftNodeParent;
                        }

                        Count--;

                        return true;
                    }

                    while (minLeftNode.Left is not null)
                    {
                        minLeftNodeParent = minLeftNode;
                        minLeftNode = minLeftNodeParent.Left;
                    }

                    if (minLeftNode.Right is not null)
                    {
                        minLeftNodeParent.Left = minLeftNode.Right;
                    }
                    else
                    {
                        minLeftNodeParent.Left = null;
                    }

                    minLeftNode.Left = deletedNode.Left;
                    minLeftNode.Right = deletedNode.Right;

                    if (deletedNode == deletedNodeParent.Left)
                    {
                        deletedNodeParent.Left = minLeftNode;
                    }
                    else
                    {
                        deletedNodeParent.Right = minLeftNode;
                    }
                }
            }

            Count--;

            return true;
        }

        public void GoAroundInWidth(Action<T> action)
        {
            if (root is null)
            {
                return;
            }

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>(Count);

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();

                action(currentNode.Data);

                if (currentNode.Left is not null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right is not null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }

        public void GoAroundInDepthCyclically(Action<T> action)
        {
            if (root is null)
            {
                return;
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>(Count);
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();

                action(currentNode.Data);

                if (currentNode.Right is not null)
                {
                    stack.Push(currentNode.Right);
                }

                if (currentNode.Left is not null)
                {
                    stack.Push(currentNode.Left);
                }
            }
        }

        public void GoAroundInDepth(Action<T> action)
        {
            if (root is null)
            {
                return;
            }

            GoAroundInDepthRecursively(root, action);
        }

        private void GoAroundInDepthRecursively(TreeNode<T> node, Action<T> action)
        {
            action(node.Data);

            if (node.Left is not null)
            {
                GoAroundInDepthRecursively(node.Left, action);
            }

            if (node.Right is not null)
            {
                GoAroundInDepthRecursively(node.Right, action);
            }
        }
    }
}