﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class TreeNode<Employees>
    {
        public Employees Value { get; set; }

        public TreeNode<Employees> Left { get; set; }

        public TreeNode<Employees> Right { get; set; }
    }
}
