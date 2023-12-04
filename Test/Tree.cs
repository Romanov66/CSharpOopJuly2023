namespace Test
{
    internal class Tree
    {
        /*BinaryTree<IShape> binaryTree = new BinaryTree<IShape>(new AreasComparer());

            IShape circle = new Circle(13);
            IShape square = new Square(15);
            IShape rectangel = new Rectangle(5, 8);

            binaryTree.Add(circle);
            binaryTree.Add(square);
            binaryTree.Add(rectangel);*/


        /*TreeNode<T> leftChildNode = deletedNodeParent.Left;
                TreeNode<T> rightChildNode = deletedNodeParent.Right;

                if (leftChildNode is null && rightChildNode is null)
                {
                    if (deletedNodeParent.Data.CompareTo(leftChildNode.Data) > 0)
                    {
                        deletedNodeParent.Left = null;
                    }
                    else
                    {
                        deletedNodeParent.Right = null;
                    }
                }
                else if (leftChildNode.Left is not null && leftChildNode.Right is null)
                {
                    if (deletedNodeParent.Data.CompareTo(leftChildNode.Data) > 0)
                    {
                        deletedNodeParent.Left = leftChildNode.Left;
                    }
                    else
                    {
                        deletedNodeParent.Right = leftChildNode.Left;
                    }
                }
                else if (leftChildNode.Left is null && leftChildNode.Right is not null)
                {
                    if (deletedNodeParent.Data.CompareTo(leftChildNode.Data) > 0)
                    {
                        deletedNodeParent.Left = leftChildNode.Right;
                    }
                    else
                    {
                        deletedNodeParent.Right = leftChildNode.Right;
                    }
                }
                else
                {
                    TreeNode<T> deletedNodeParent = deletedNodeParent;
                    TreeNode<T> deletedNode = leftChildNode;
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

                Count--;

                return;
            }

            int result = deletedNode.Data.CompareTo(data);

            if (result > 0)
            {
                if (deletedNode.Left is not null)
                {
                    deletedNodeParent = deletedNode;
                    deletedNode = deletedNode.Left;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (deletedNode.Right is not null)
                {
                    deletedNodeParent = deletedNode;
                    deletedNode = deletedNode.Right;
                }
                else
                {
                    return;
                }
            }*/

    }

}