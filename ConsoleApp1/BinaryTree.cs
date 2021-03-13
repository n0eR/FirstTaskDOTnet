using System;
using System.Collections.Generic;
using System.Text;

namespace MainNamespace
{
    public enum Side
    {
        Left,
        Right
    }
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode(int Data) { this.Data = Data; }

        public TreeNode LeftNode { get; set; }

        public TreeNode RightNode { get; set; }

        public TreeNode ParentNode { get; set; }

        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;
    }

    public class BinaryTree
    {
        public TreeNode RootNode { get; set; }

        public TreeNode AddNode(int Data)
        {
            return AddNode(new TreeNode(Data));
        }

        public TreeNode AddNode(TreeNode node, TreeNode currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Data.CompareTo(currentNode.Data)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : AddNode(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : AddNode(node, currentNode.RightNode);
        }

        public TreeNode FindNode(int data, TreeNode start_with_node = null)
        {
            start_with_node = start_with_node ?? RootNode;
            int result;
            return (result = data.CompareTo(start_with_node.Data)) == 0
                ? start_with_node
                : result < 0
                    ? start_with_node.LeftNode == null
                        ? null
                        : FindNode(data, start_with_node.LeftNode)
                    : start_with_node.RightNode == null
                        ? null
                        : FindNode(data, start_with_node.RightNode);
        }

        public void Remove(int data)
        {
            var found_node = FindNode(data);
            RemoveNode(found_node);
        }

        public void RemoveNode(TreeNode node)
        {
            if (node == null) return;

            var current_node_side = node.NodeSide;
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (current_node_side == Side.Left) node.ParentNode.LeftNode = null;
                else node.ParentNode.RightNode = null;
            }
            else if (node.LeftNode == null)
            {
                if (current_node_side == Side.Left) node.ParentNode.LeftNode = node.RightNode;
                else node.ParentNode.RightNode = node.RightNode;

                node.RightNode.ParentNode = node.ParentNode;
            }
            else if (node.RightNode == null)
            {
                if (current_node_side == Side.Left) node.ParentNode.LeftNode = node.LeftNode;
                else node.ParentNode.RightNode = node.LeftNode;       

                node.LeftNode.ParentNode = node.ParentNode;
            }
            else
            {
                switch (current_node_side)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        AddNode(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        AddNode(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        AddNode(bufLeft, node);
                        break;
                }
            }
        }

        public void PrintTree()
        {
            PrintTree(RootNode);
        }
        private void PrintTree(TreeNode startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                indent += new string(' ', 3);

                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }

    }
}
