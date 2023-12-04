﻿namespace TreeTask
{
    public class BinarySearchTree<T>
    {
        private TreeNode<T> root;
        private readonly IComparer<T> comparator;

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
            TreeNode<T> newNode = new TreeNode<T>(data);

            while (true)
            {
                int comparisonResult = Compare(currentNode.Data, newNode.Data);

                if (comparisonResult > 0)
                {
                    if (currentNode.Left is null)
                    {
                        currentNode.Left = newNode;
                        Count++;

                        return;
                    }

                    currentNode = currentNode.Left;
                }
                else
                {
                    if (currentNode.Right is null)
                    {
                        currentNode.Right = newNode;
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

            TreeNode<T> deletedNodeParent = null;
            TreeNode<T> deletedNode = root;

            while (deletedNode is not null)
            {
                int comparisonResult = Compare(deletedNode.Data, data);

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
            }

            if (deletedNode is null)
            {
                return false;
            }

            if (deletedNode.Left is null && deletedNode.Right is null)
            {
                if (deletedNodeParent is null)
                {
                    root = null;
                    Count = 0;

                    return true;
                }

                if (deletedNode == deletedNodeParent.Left)
                {
                    deletedNodeParent.Left = null;
                }
                else
                {
                    deletedNodeParent.Right = null;
                }

                Count--;

                return true;
            }

            if (deletedNode.Left is null || deletedNode.Right is null)
            {
                if (deletedNodeParent is null)
                {
                    if (deletedNode.Left is null)
                    {
                        root = deletedNode.Right;
                    }
                    else
                    {
                        root = deletedNode.Left;
                    }

                    Count--;

                    return true;
                }

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

                Count--;

                return true;
            }

            TreeNode<T> minLeftNodeParent = deletedNode.Right;
            TreeNode<T> minLeftNode = minLeftNodeParent.Left;

            if (minLeftNode is null)
            {
                if (deletedNodeParent is null)
                {
                    minLeftNodeParent.Left = root.Left;

                    root = minLeftNodeParent;
                    Count--;

                    return true;
                }

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
                minLeftNode = minLeftNode.Left;
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

            if (deletedNodeParent is null)
            {
                root = minLeftNode;
                Count--;

                return true;
            }

            if (deletedNode == deletedNodeParent.Left)
            {
                deletedNodeParent.Left = minLeftNode;
            }
            else
            {
                deletedNodeParent.Right = minLeftNode;
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