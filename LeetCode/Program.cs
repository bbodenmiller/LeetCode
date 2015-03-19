using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            #region sum of tree paths
            /*BinaryTreeNode tree = new BinaryTreeNode(1);
            tree.left = new BinaryTreeNode(2);
            tree.right = new BinaryTreeNode(4);
            tree.right.right = new BinaryTreeNode(2);
            tree.right.right.left = new BinaryTreeNode(8);
            tree.right.left = new BinaryTreeNode(40);

            var temp = SumofTreePaths(tree);*/
            #endregion

            #region 111 Minimum Depth of Binary Tree
            /*TreeNode tree = new TreeNode(1);
            tree.left = new TreeNode(2);
            tree.right = new TreeNode(4);
            tree.right.right = new TreeNode(2);
            tree.right.right.left = new TreeNode(8);
            tree.right.left = new TreeNode(40);

            var minDepthofBinaryTree = MinDepth(tree);*/
            #endregion

            #region 136 Single Number
            /*var numbers = new int[] {1, 2, 2, 3, 3, 4, 4, 5, 5};

            SingleNumber(numbers);
            */
            #endregion

            #region 143 Reorder List
            /*var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);

            ReorderList(head);*/
            #endregion

            #region 191 Number of 1 Bits
            //Console.WriteLine("191: " + HammingWeight(00000000000000000000000000001011));
            //Console.WriteLine("191: " + HammingWeight(0x00000000000000000000000000000010));
            #endregion

            Console.WriteLine("");
            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }

        #region sum of tree paths
        public class BinaryTreeNode
        {
            public int val;
            public BinaryTreeNode left;
            public BinaryTreeNode right;

            public BinaryTreeNode(int x)
            {
                val = x;
                left = null;
                right = null;
            }
        }

        /*
         * Calculate the sum of all numbers formed by paths from root to leaf.
         */
        public static ArrayList results = new ArrayList();
        public static int count = 0;

        public static ArrayList SumofTreePaths(BinaryTreeNode node)
        {
            if (node == null)
            {
                return results;
            }

            count += node.val;

            if (node.left == null && node.right == null)
            {
                results.Add(count);
            }

            if (node.left != null)
            {
                SumofTreePaths(node.left);
            }

            if (node.right != null)
            {
                SumofTreePaths(node.right);
            }

            count -= node.val;

            return results;
        }
        #endregion

        #region 111 Minimum Depth of Binary Tree
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static int MinDepth(TreeNode root)
        {
            int min = 0;
            int minLeft = -1;
            int minRight = -1;
            int minChild = 0;

            if (root==null)
            {
                return min;
            }
            else
            {
                min++;
            }

            //if (root.left == null && root.right == null)
            //{
            //    return min;
            //}
            //else
            //{
            //    return min + Math.Min(MinDepth(root.left), MinDepth(root.right));
            //}

            //get min depth of children trees
            if (root.left != null)
            {
                minLeft = MinDepth(root.left);
            }

            if (root.right != null)
            {
                minRight = MinDepth(root.right);
            }

            //find smallest child that exists
            if (minLeft > 0 && minRight > 0)
            {
                minChild = Math.Min(minLeft, minRight);
            }
            else if (minLeft > 0)
            {
                minChild = minLeft;
            }
            else if (minRight > 0)
            {
                minChild = minRight;
            }

            return min + minChild;
        }
        #endregion

        #region 136
        /*
         * Given an array of integers, every element appears twice except for one. Find that single one.
         * 
         * Note: Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
         */
        static public int SingleNumber(int[] A)
        {
            int value = 0;
            for (int i = 0; i < A.Length; i++)
            {
                value = value ^ A[i]; //^ is XOR, see https://msdn.microsoft.com/en-us/library/zkacc7k1.aspx
            }
            return value;

            //use following if numbers do not appear exactly twice or if you are looking for more than one number with only 1 occurrence
            var numberCount = new Dictionary<int, int>();

            foreach (int number in A)
            {
                if (!numberCount.Remove(number))
                {
                    numberCount.Add(number, 1);
                }
            }

            var min = numberCount.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

            return min;
        }
        #endregion

        #region 143
        /* 
         * Given a singly linked list L: L0→L1→…→Ln-1→Ln, reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…
         * You must do this in-place without altering the nodes' values.
         * For example,
         * Given {1,2,3,4}, reorder it to {1,4,2,3}.
         */
        static public void ReorderList(ListNode head)
        {
            if (head != null && head.next != null)
            {
                //split in to two lists
                //1.find middle of list to get start of next list
                var slow = head;
                var fast = head;

                while (slow.next != null && fast.next != null && fast.next.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }

                //2.split lists
                var second = slow.next;
                slow.next = null; //end first

                //reverse second list
                var prev = second;
                var current = second.next;
                while (current != null)
                {
                    var temp = current.next;
                    current.next = prev;
                    prev = current;
                    current = temp;
                }

                //set second.next to null as first element is now last
                second.next = null;

                //set new head for second
                second = prev;

                //merge lists
                var l1 = head;
                var l2 = second;

                while (l2 != null)
                {
                    var temp1 = l1.next;
                    var temp2 = l2.next;

                    l1.next = l2;
                    l2.next = temp1;

                    l1 = temp1;
                    l2 = temp2;
                }
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
        #endregion

        #region 191
        /* 
         * Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).
         * 
         * For example, the 32-bit integer ’11' has binary representation 00000000000000000000000000001011, so the function should return 3.
         */
        static public int HammingWeight(uint n)
        {
            //from http://stackoverflow.com/a/109915/1233435
            int count = 0;
            while (n > 0)
            {           // until all bits are zero
                if ((n & 0x01) == 1)     // check lower bit
                    count++;
                n = n >> 1;              // shift right bits, removing lower bit - see https://en.wikipedia.org/wiki/Bitwise_operation#Logical_shift
            }
            return count;

            //lazy solution - convert to string
            String strn = n.ToString();

            int count2 = 0;
            foreach (var c in strn)
            {
                if (c.Equals('1'))
                {
                    count2++;
                }
            }

            return count2;
        }
        #endregion
    }
}
