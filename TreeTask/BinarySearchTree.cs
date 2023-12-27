namespace TreeTask
{
    public class BinarySearchTree<T>
    {
        private readonly IComparer<T> comparator;

        private TreeNode<T> root;

        public int Count { get; private set; }

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(IComparer<T> comparator)
        {
            this.comparator = comparator;
        }

        private int Compare(T data1, T data2)
        {
            if (comparator is not null)
            {
                return comparator.Compare(data1, data2);
            }

            if (data1 == null && data2 == null)
            {
                return 0;
            }

            if (data1 == null)
            {
                return -1;
            }

            if (data2 == null)
            {
                return 1;
            }

            IComparable<T> comparable = (IComparable<T>)data1;

            return comparable.CompareTo(data2);
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

            while (true)
            {
                if (Compare(currentNode.Data, data) > 0)
                {
                    if (currentNode.Left is null)
                    {
                        currentNode.Left = new TreeNode<T>(data);
                        Count++;

                        return;
                    }

                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right is null)
                    {
                        currentNode.Right = new TreeNode<T>(data);
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
            if (root is null)
            {
                return false;
            }

            TreeNode<T> removedNodeParent = null;
            TreeNode<T> removedNode = root;

            while (removedNode is not null)
            {
                int comparisonResult = Compare(removedNode.Data, data);

                if (comparisonResult == 0)
                {
                    break;
                }

                if (comparisonResult > 0)
                {
                    removedNodeParent = removedNode;
                    removedNode = removedNodeParent.Left;
                }
                else
                {
                    removedNodeParent = removedNode;
                    removedNode = removedNodeParent.Right;
                }
            }

            if (removedNode is null)
            {
                return false;
            }

            if (removedNode.Left is null && removedNode.Right is null)
            {
                if (removedNodeParent is null)
                {
                    root = null;
                }
                else if (removedNode == removedNodeParent.Left)
                {
                    removedNodeParent.Left = null;
                }
                else
                {
                    removedNodeParent.Right = null;
                }

                Count--;

                return true;
            }

            if (removedNode.Left is null || removedNode.Right is null)
            {
                TreeNode<T> childRemovedNote;

                if (removedNode.Left is null)
                {
                    childRemovedNote = removedNode.Right;
                }
                else
                {
                    childRemovedNote = removedNode.Left;
                }

                if (removedNodeParent is null)
                {
                    root = childRemovedNote;
                }
                else if (removedNode == removedNodeParent.Left)
                {
                    removedNodeParent.Left = childRemovedNote;
                }
                else
                {
                    removedNodeParent.Right = childRemovedNote;
                }

                Count--;

                return true;
            }

            TreeNode<T> minLeftNodeParent = removedNode.Right;

            if (minLeftNodeParent.Left is null)
            {
                minLeftNodeParent.Left = removedNode.Left;

                if (removedNodeParent is null)
                {
                    root = minLeftNodeParent;
                }
                else if (removedNode == removedNodeParent.Left)
                {
                    removedNodeParent.Left = minLeftNodeParent;
                }
                else
                {
                    removedNodeParent.Right = minLeftNodeParent;
                }

                Count--;

                return true;
            }

            TreeNode<T> minLeftNode = minLeftNodeParent.Left;

            while (minLeftNode.Left is not null)
            {
                minLeftNodeParent = minLeftNode;
                minLeftNode = minLeftNode.Left;
            }

            minLeftNodeParent.Left = minLeftNode.Right;
            minLeftNode.Left = removedNode.Left;
            minLeftNode.Right = removedNode.Right;

            if (removedNodeParent is null)
            {
                root = minLeftNode;
            }
            else if (removedNode == removedNodeParent.Left)
            {
                removedNodeParent.Left = minLeftNode;
            }
            else
            {
                removedNodeParent.Right = minLeftNode;
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

        public void GoAroundInDepth(Action<T> action)
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

        public void GoAroundInDepthRecursively(Action<T> action)
        {
            if (root is null)
            {
                return;
            }

            GoAroundInDepthRecursively(root, action);
        }

        private static void GoAroundInDepthRecursively(TreeNode<T> node, Action<T> action)
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