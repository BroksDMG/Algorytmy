using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTTree<int> tree = new BSTTree<int>() { Root = new TreeNode<int> { Value = 15 } };
            tree.Root.Left = new TreeNode<int>() { Value = 14, Left = new TreeNode<int> { Value = 7},Rgiht= new TreeNode<int>() {Value=10} };
            tree.Root.Rgiht = new TreeNode<int>() { Value = 20, Left = new TreeNode<int> { Value = 19},Rgiht= new TreeNode<int>() {Value=40} };
            tree.Print();
            Console.WriteLine(tree.Contains(7));
            Console.WriteLine(tree.Contains(71));
           
            

            SortedSet<int> sorted = new SortedSet<int>();
            sorted.Add(10);
            sorted.Add(2);
            sorted.Add(20);
            sorted.Add(12);
            sorted.Add(4);
            sorted.Remove(10);

            foreach(var item in sorted)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(", ", sorted.GetViewBetween(10, 20)));
            sorted.UnionWith(Enumerable.Range(4, 12));
            Console.WriteLine(string.Join(", ", sorted));

            SortedSet<Student> studenst = new SortedSet<Student>(new StudentComparer());
            studenst.Add(new Student("Adam",123));
            studenst.Add(new Student("Ewa",23));
            studenst.Add(new Student("Adam",13));
            Console.WriteLine(string.Join(", ", studenst));
            Console.WriteLine(studenst.Contains(new Student("Ewa",23)));
            Console.WriteLine(studenst.Contains(new Student("Karol",23)));

            //utwórz i przetestuj BSTtree dla łańcuchów :czyli sprawdź działenie Contains
            //adam ,ewa ,robert, karol, tomek (adam,ewa,karol,robert,tomek)

            SortedSet<NameExample> names = new SortedSet<NameExample>(new NameExampleComparer());
            names.Add(new NameExample("Krol"));
            names.Add(new NameExample("Tomek"));
            names.Add(new NameExample("Adam"));
            names.Add(new NameExample("Ewa"));
            names.Add(new NameExample("Robert"));
            names.Add(new NameExample("Lucek"));
            names.Add(new NameExample("Franek"));
            Console.WriteLine(string.Join(", ", names));

        }
    }
    class NameExampleComparer : IComparer<NameExample>
    {

        public int Compare(NameExample x, NameExample y)
        {
            if (x is null)
            {
                throw new NotImplementedException();

            }
            int r = x.Name.CompareTo(y.Name);
            return r;
        }
    }
        record NameExample(string Name);
        class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {   
            if(x is null)
            {
                throw new NullReferenceException();
            }
            int r = x.Name.CompareTo(y.Name);
            return r == 0 ? x.Ects.CompareTo(y.Ects) : r;


        }
    }

    record Student(string Name, int Ects);
    class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Rgiht { get; set; }

    }
    class BSTTree<T> where T:IComparable<T>
    {
        public TreeNode<T> Root { get; set; }

        public bool Contains(T value)
        {
            return RecursiveContains(Root, value);
        }
        private bool RecursiveContains(TreeNode<T> node,T searchValue)
        {
            if(node is null)
            {
                return false;
            }
            int r = node.Value.CompareTo(searchValue);
            if (r == 0) 
            {
                return true;
            }
            if (r < 0)
            {
                return RecursiveContains(node.Rgiht, searchValue);
            }
            else
            {
                return RecursiveContains(node.Left, searchValue);
            }

        }
        public void Print()
        {
            RecursivePrint(Root,0);

        }
        private void RecursivePrint(TreeNode<T> node , int level)
        {   
            if(node is null)
            {
                return;
            }
            string ident = string.Concat(Enumerable.Repeat("-", level));
            Console.WriteLine(ident +node.Value);
            RecursivePrint(node.Left, level +1);
            RecursivePrint(node.Rgiht, level+1);
        }
    }
}
