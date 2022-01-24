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
        MyNode StartNode;
        readonly List<MyNode> Template = new();
        List<MyNode> Items;
        MyNode Temp;
        public int Size;

        public MyNode Last;
        public MyNode First;

		public MyStringLinkedList()
        {
            Items = Template;
        }

        private MyStringLinkedList(MyNode node)
        {

        }

        public MyStringLinkedList(IEnumerable<string> dataList)
        {
            foreach (var item in dataList)
            {
                var temp = new MyNode(item);
                Items.Add(temp);
            }
            Size = Items.Count;
            First = GetFirst();
            Last = GetLast();
        }

        public new int Count() => Size;

        MyNode GetLast()
        {
            var lastItem = Items[^1];
            return lastItem;
        }

        MyNode GetFirst()
        {
            var firstItem = Items[0];
            return firstItem;
        }

        public void AddValue(string value)
        {
            var node = new MyNode(value);

            if (StartNode == null)
                StartNode = node;
            else
            {
                var current = StartNode;

                while (current.NextNode != null)
                    current = current.NextNode;

                current.NextNode = node;
            }
        }

        public void AddFirst()
        {

        }

        public void AddAfter(MyNode nodePoint, string value)
        {
            var node = new MyNode(value);
            var current = StartNode;

            while (current != nodePoint)
                current = current.NextNode;

            current = current.NextNode;
            node.NextNode = current.NextNode;
            current.NextNode = node;

            while (current != null)
                current = current.NextNode;
        }

        public void AddBefore(MyNode nodePoint, string value)
        {
            var node = new MyNode(value);
            var current = StartNode;

            while (current != nodePoint)
                current = current.NextNode;

            node.NextNode = current.NextNode;
            current.NextNode = node;

            while (current != null)
                current = current.NextNode;
        }

        public void Remove(MyNode removingNode)
        {
            var current = StartNode;

            while (current.NextNode != null)
            {
                if (current != removingNode)
                    current = current.NextNode;
                else
                    current = current.NextNode.NextNode;
            }
        }

        public void GetItemByIndex(int index)
        {
            if (index >= Size)
                throw new IndexOutOfRangeException();

            Console.WriteLine(Items[index].Value);
        }

       
    }
}
