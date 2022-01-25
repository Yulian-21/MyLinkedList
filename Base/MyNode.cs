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
            NextNode = null;
            PreviousNode = null;
            //this = NextNode;
            MyList.AddLast(Value);
        }
    }
}
