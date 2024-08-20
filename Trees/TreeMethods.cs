using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Trees
{
    public class TreeMethods
    {
        public TreeNode<Employees>? OriginRoot { get; set; }
        public void RunEntireProgram()
        {
            OriginRoot = null;
            List<Employees> lists = new()
            {
                new Employees() { Name = "Marina", Salary = 80000 },
                new Employees() { Name = "Dima", Salary = 90000 },
                new Employees() { Name = "Maks", Salary = 100000 },
                new Employees() { Name = "Oleg", Salary = 60000 },
                new Employees() { Name = "Egor", Salary = 30000 },
                new Employees() { Name = "Olga", Salary = 200000 },
            };

            foreach (Employees employee in lists)
            {
                OriginRoot = TreeBuilder(OriginRoot, employee);
            }

            OriginRoot = AddConsoleInputs(OriginRoot);
            PrintAllEmployees(OriginRoot);
            FindNumber(OriginRoot);
        }
        public TreeNode<Employees> AddConsoleInputs(TreeNode<Employees> root)
        {
            string? inputName;
            string? inputSalary;
            decimal salary;
            bool salaryParser;
            Employees? newNode;

            while (true)
            {
                Console.WriteLine("Employee name");
                inputName = Console.ReadLine();
                if (inputName == "") 
                    break;

                do
                {
                    Console.WriteLine("Employee salary");
                    inputSalary = Console.ReadLine();
                    salaryParser = decimal.TryParse(inputSalary, out salary);
                    if (!salaryParser) 
                    { 
                        Console.WriteLine("Error: input wrong format!"); 
                    }
                } 
                while (!salaryParser);

                newNode = new Employees() 
                { 
                    Name = inputName, 
                    Salary = salary 
                };

                TreeBuilder(root, newNode);
            }
            return root;
        }
        public TreeNode<Employees> TreeBuilder(TreeNode<Employees> root, Employees? newNode)
        {
            if (root == null)
            {
                root = new TreeNode<Employees>()
                {
                    Value = newNode
                };
            }
            else
            {
                AddNode(root, new TreeNode<Employees>()
                {
                    Value = newNode
                });
            }
            return root;
        }
        public void AddNode(TreeNode<Employees> rootNode, TreeNode<Employees> nodeToAdd)
        {
            if (nodeToAdd.Value.Salary < rootNode.Value.Salary)
            {
                if (rootNode.Left != null)
                {
                    AddNode(rootNode.Left, nodeToAdd);
                }
                else
                {
                    rootNode.Left = nodeToAdd;
                }
            }
            else
            {
                if (rootNode.Right != null)
                {
                    AddNode(rootNode.Right, nodeToAdd);
                }
                else
                {
                    rootNode.Right = nodeToAdd;
                }
            }
        }

        public void PrintAllEmployees(TreeNode<Employees>? root)
        {
            Console.WriteLine();
            Console.WriteLine("Full list of employees:");
            SortedEmployees(root);
        }

        public void SortedEmployees(TreeNode<Employees> root)
        {

            if (root.Left != null)
            {
                SortedEmployees(root.Left);
            }

            Console.WriteLine($"{root.Value.Name} - {root.Value.Salary}");


            if (root.Right != null)
            {
                SortedEmployees(root.Right);
            }
        }

        public void FindNumber(TreeNode<Employees>? root)
        {
            string? input;
            decimal requestedSalary;
            TreeNode<Employees> node;

            Console.WriteLine();
            Console.WriteLine("Enter salary to find employee:");

            input = Console.ReadLine();
            requestedSalary = int.Parse(input);

            node = FindNode(root, requestedSalary);
            Console.WriteLine();

            if (node != null)
            {
                Console.WriteLine($"Employee name: {node.Value.Name}");
            }
            else
            {
                Console.WriteLine($"No such employee found!");
            }
        }

        public TreeNode<Employees> FindNode(TreeNode<Employees> rootNode, decimal number)
        {
            if (number < rootNode.Value.Salary)
            {
                if (rootNode.Left != null)
                {
                    return FindNode(rootNode.Left, number);
                }

                return null;
            }
            if (number > rootNode.Value.Salary)
            {
                if (rootNode.Right != null)
                {
                    return FindNode(rootNode.Right, number);
                }

                return null;
            }

            return rootNode;
        }
    }
}
