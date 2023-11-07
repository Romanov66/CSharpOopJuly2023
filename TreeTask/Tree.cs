namespace TreeTask
{
    internal class Tree<T> where T : IComparable<T>
    {
        public TreeNode<T> RootNode { get; set; }
        int count;

        public Tree()
        {
            RootNode = null;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }


        public void Add(TreeNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Переданный аргумент не может быть null", nameof(node));
            }

            if (RootNode == null)
            {
                RootNode = node;
                count++;

                return;
            }

            TreeNode<T> currentNode = RootNode;

            while (currentNode is not null)
            {
                int result = currentNode.Data.CompareTo(node.Data);

                if (result > 0)
                {
                    if (currentNode.Left is not null)
                    {
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        currentNode.Left = node;
                        count++;

                        return;
                    }
                }

                if (result <= 0)
                {
                    if (currentNode.Right is not null)
                    {
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        currentNode.Right = node;
                        count++;

                        return;
                    }
                }
            }
        }

        public TreeNode<T> FindNote(T serchElement)
        {
            if (serchElement == null)
            {
                throw new ArgumentNullException("Переданный аргумент не может быть null", nameof(serchElement));
            }

            TreeNode<T> currentNode = RootNode;
            TreeNode<T> serchNode = null;

            while (currentNode is not null)
            {
                if (currentNode.Data.Equals(serchElement))
                {
                    serchNode = currentNode;

                    break;
                }

                int result = currentNode.Data.CompareTo(serchElement);

                if (result > 0)
                {
                    if (currentNode.Left is not null)
                    {
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        break;
                    }
                }

                if (result <= 0)
                {
                    if (currentNode.Right is not null)
                    {
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return serchNode;
        }

        public void Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Переданный аргумент не может быть null", nameof(element));
            }

            TreeNode<T> nextNode = RootNode;
            TreeNode<T> currnetNode = null;

            while (nextNode is not null)
            {
                if (nextNode.Data.Equals(element))
                {
                    if (nextNode.Data.Equals(RootNode.Data))
                    {
                        RootNode = null;
                        count = 0;
                    }
                    else if (nextNode.Left is null && nextNode.Right is null)
                    {
                        if (currnetNode.Data.CompareTo(nextNode.Data) > 0)
                        {
                            currnetNode.Left = null;
                        }
                        else
                        {
                            currnetNode.Right = null;
                        }
                    }
                    else if (nextNode.Left is not null && nextNode.Right is null)
                    {
                        if (currnetNode.Data.CompareTo(nextNode.Data) > 0)
                        {
                            currnetNode.Left = nextNode.Left;
                        }
                        else
                        {
                            currnetNode.Right = nextNode.Left;
                        }
                    }
                    else if (nextNode.Left is null && nextNode.Right is not null)
                    {
                        if (currnetNode.Data.CompareTo(nextNode.Data) > 0)
                        {
                            currnetNode.Left = nextNode.Right;
                        }
                        else
                        {
                            currnetNode.Right = nextNode.Right;
                        }
                    }
                    else
                    {
                        TreeNode<T> deletedNodeParent = currnetNode;
                        TreeNode<T> deletedNode = nextNode;
                        TreeNode<T> minLeftNodeParent = deletedNode.Right;
                        TreeNode<T> minLeftNode = minLeftNodeParent.Left;

                        if (minLeftNodeParent is null)
                        {
                            if (deletedNode.Left is not null)
                            {
                                if (deletedNodeParent.Data.CompareTo(deletedNode.Data) > 0)
                                {
                                    deletedNodeParent.Left = deletedNode.Left;
                                }
                                else
                                {
                                    deletedNodeParent.Right = deletedNode.Left;
                                }
                            }
                            else
                            {
                                if (deletedNodeParent.Data.CompareTo(deletedNode.Data) > 0)
                                {
                                    deletedNodeParent.Left = null;
                                }
                                else
                                {
                                    deletedNodeParent.Right = null;
                                }
                            }
                        }

                        while (minLeftNode is not null)
                        {
                            if (minLeftNode.Left is not null)
                            {
                                minLeftNodeParent = minLeftNode;
                                minLeftNode = minLeftNode.Left;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (minLeftNode.Right is not null)
                        {
                            minLeftNodeParent.Left = minLeftNode.Right;
                        }

                        minLeftNode.Left = deletedNode.Left;
                        minLeftNode.Right = deletedNode.Right;

                        if (deletedNodeParent.Data.CompareTo(deletedNode.Data) > 0)
                        {
                            deletedNodeParent.Left = minLeftNode;
                        }
                        else
                        {
                            deletedNodeParent.Right = minLeftNode;
                        }
                    }

                    count--;

                    return;
                }

                int result = nextNode.Data.CompareTo(element);

                if (result > 0)
                {
                    if (nextNode.Left is not null)
                    {
                        currnetNode = nextNode;
                        nextNode = nextNode.Left;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (nextNode.Right is not null)
                    {
                        currnetNode = nextNode;
                        nextNode = nextNode.Right;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public void RunWide()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>(count);
            queue.Enqueue(RootNode);

            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();

                if (currentNode is not null)
                {
                    Console.WriteLine(currentNode.Data);

                    queue.Enqueue(currentNode.Left);
                    queue.Enqueue(currentNode.Right);
                }
            }
        }

        public void RunHighRecursivly(TreeNode<T> node)
        {
            Console.WriteLine(node.Data);

            TreeNode<T>[] children = { node.Left, node.Right };

            foreach (TreeNode<T> child in children)
            {
                if (child is not null)
                {
                    RunHighRecursivly(child);
                }
            }
        }

        public void RunHigh()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>(count);
            stack.Push(RootNode);

            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();

                if (currentNode is not null)
                {
                    Console.WriteLine(currentNode.Data);

                    stack.Push(currentNode.Right);
                    stack.Push(currentNode.Left);
                }
            }
        }
    }
}