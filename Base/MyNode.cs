using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList.Base
{
    public class MyNode
    {
        
        public MyNode NextNode;
        public MyNode PreviousNode;
        public MyStringLinkedList MyList;
        public string Value;

        public MyNode(string value)
        {
            
            Value = value;
            PreviousNode = MyList.Last;

           // MyList.AddLast(this);
        }

        public MyNode(MyNode lastNode, MyNode newNode)
        {

        }

        public MyNode(MyStringLinkedList list)
        {
            MyList = list;
        }
    }
}
