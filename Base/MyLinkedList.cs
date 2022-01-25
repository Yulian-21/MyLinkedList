using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList.Base
{
    public class MyStringLinkedList
    {
        MyNode HeaderNode;

        public int Size;
        public MyNode Last;
        public MyNode First;

		public MyStringLinkedList()
        {
            
        }

        public MyStringLinkedList(IEnumerable<string> dataList)
        {
            foreach (var item in dataList)
            {
                AddLast(item);
            }

            Size = Count();
            First = GetFirst();
            Last = GetLast();
        }

        /// <summary>
        /// Represent the size of collection
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            var current = HeaderNode;
            var counter = 0;

            if (current == null)
                throw new Exception("List is empty");
            else
            {
                while (current.NextNode != null)
                    counter++;
                
                return counter;
            }
        }

        /// <summary>
        /// Get last item in collection
        /// </summary>
        /// <returns></returns>
        MyNode GetLast()
        {
            var current = HeaderNode;

            while (current.NextNode != null)
            {
                current.PreviousNode = current;
                current = current.NextNode;
            }

            return current;
        }

        /// <summary>
        /// Get the first item in collection
        /// </summary>
        /// <returns></returns>
        MyNode GetFirst()
        {
            var current = Last;

            while (current.PreviousNode != null)
            {
                current.NextNode = current;
                current = current.PreviousNode;
            }
            return current;
        }

        /// <summary>
        /// Adding value in the end of collection
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(string value)
        {
            var node = new MyNode(value);

            if (HeaderNode == null)
                HeaderNode = node;
            else
            {
                var current = HeaderNode;

                while (current.NextNode != null)
                {
                    current.PreviousNode = current;
                    current = current.NextNode;
                }

                current.NextNode = node;
            }
        }

        /// <summary>
        /// Add element to the Start of collection and move all elements on 1 node
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(string value)
        {
            var node = new MyNode(value);
            node.NextNode = HeaderNode;
            HeaderNode = node;
        }

        /// <summary>
        /// Adding value after specified existing node
        /// </summary>
        /// <param name="nodePoint"></param>
        /// <param name="value"></param>
        public void AddAfter(MyNode nodePoint, string value)
        {
            var node = new MyNode(value);
            var current = HeaderNode;

            while (current != nodePoint)
            {
                current.PreviousNode = current;
                current = current.NextNode;
            }
                
            current = current.NextNode;
            current.PreviousNode = current;
            node.NextNode = current.NextNode;
            current.NextNode = node;

            while (current != null)
            {
                current.PreviousNode = current;
                current = current.NextNode;
            }
        }

        /// <summary>
        /// Adding value before specified existing node
        /// </summary>
        /// <param name="nodePoint"></param>
        /// <param name="value"></param>
        public void AddBefore(MyNode nodePoint, string value)
        {
            var node = new MyNode(value);
            var current = HeaderNode;

            while (current != nodePoint)
            {
                current.PreviousNode = current;
                current = current.NextNode;
            }      

            node.PreviousNode = current;
            node.NextNode = current.NextNode;
            current.NextNode = node;

            while (current != null)
            {
                current.PreviousNode = current;
                current = current.NextNode;
            }
        }

        /// <summary>
        /// Remove specified node from collection
        /// </summary>
        /// <param name="removingNode"></param>
        public void Remove(MyNode removingNode)
        {
            var current = HeaderNode;

            while (current.NextNode != null)
            {
                if (current != removingNode)
                    current = current.NextNode;
                else
                {
                    current.PreviousNode = current;
                    current = current.NextNode.NextNode;
                }
            }
        }

        /// <summary>
        /// Find the first node that contains the specified value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MyNode Find(string value)
        {
            var current = HeaderNode;

            while (current.NextNode.Value != value)
                current = current.NextNode;
            
            
            return current.NextNode;
        }

        /// <summary>
        /// Find the ast node that contains the specified value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MyNode FindLast(string value)
        {
            var current = Last;

            while (current.PreviousNode.Value != value)
            {
                current = current.PreviousNode;
            }

           return current.PreviousNode;
        }



        /// <summary>
        /// Determines whether a value in a collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(string value)
        {
            var current = HeaderNode;

            while (current.NextNode != null)
            {
                if (current.Value == value)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Remove all nodes from the collection
        /// </summary>
        public void Clear()
        {
            var current = HeaderNode;
            while (current.NextNode != null)
            {
                Remove(current);
            }
        }

        /// <summary>
        /// Remove the node at the start of collection
        /// </summary>
        public void RemoveFirst()
        {
            HeaderNode = HeaderNode.NextNode;
        }

        /// <summary>
        /// Remove the node at the end of collection
        /// </summary>
        public void RemoveLast()
        {
            var current = HeaderNode;

            while (current.NextNode != GetLast())
            {
                current = current.NextNode;
            }

            Remove(current.NextNode);
        }
    }
}
