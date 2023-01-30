﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Tree_depth_calculation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Branch root = new Branch();

            // populate tree
            PopulateTree(root, 0);
            // Calculate and print tree depth
            Console.WriteLine("\n\nRandom tree depth is = " + TreeDepth(root));

            Console.WriteLine("\n\nExample tree depth is = " + TreeDepth(ExampleTree()));
            return;
        }

        public static int TreeDepth(Branch root)
        {
            List<Branch> branches =  root.GetBranches();
            int maxDepth = 0;

            // base case
            if (branches.Count == 0)
                return 0;

            // find max depth from current node
            foreach(var branch in branches)
            {
                int depth = TreeDepth(branch);
                
                if (maxDepth < depth)
                    maxDepth = depth;
            }

            // add current node to subtree depth and return
            return maxDepth + 1;
        }

        public static void PopulateTree(Branch root, int depth)
        {

            Console.WriteLine("\nprev depth: " + depth);
            Random rnd = new Random();
            depth++;


            // base case (random depth 2 - 10)
            if (depth > rnd.Next(2, 10))
                return;

            // populate random width subtree
            int branches = rnd.Next(1, 5);

            Console.WriteLine("width: " + branches);

            for (int j = 0; j < branches; j++)
            {
                Branch newB = new Branch();
                PopulateTree(newB, depth);

                root.AddBranch(newB);
            }
        }

        public static Branch ExampleTree()
        {
            // depth 0
            Branch root = new Branch();

            // depth 1
            root.AddBranch(new Branch());

            root.AddBranch(new Branch());

            // depth 2
            root.GetBranches()[0].AddBranch(new Branch());
            
            root.GetBranches()[1].AddBranch(new Branch());
            root.GetBranches()[1].AddBranch(new Branch());
            root.GetBranches()[1].AddBranch(new Branch());

            // depth 3
            root.GetBranches()[1].GetBranches()[0].AddBranch(new Branch());

            root.GetBranches()[1].GetBranches()[1].AddBranch(new Branch());
            root.GetBranches()[1].GetBranches()[1].AddBranch(new Branch());

            // depth 4
            root.GetBranches()[1].GetBranches()[1].GetBranches()[0].AddBranch(new Branch());

            return root;
        }
    }
}
