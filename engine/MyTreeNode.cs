using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Übung.engine
{
    public class MyTreeNode : TreeNode
    {
        protected virtual void Dispose(bool disposing)
        {
           /* if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);*/
        }
    }
}
