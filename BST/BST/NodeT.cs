using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    internal class NodeT
    {
       public NodeT rodzic;
       public NodeT lewe;
       public NodeT prawe;
       public int data;
        public NodeT(int data)
        {
            this.data = data;
            this.rodzic = null;
            this.prawe = null;
            this.lewe = null;
        }
    }
}
