namespace PROG7312_POE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<Employee> tr = new Tree<Employee>(new Node<Employee>(new(100,"Jamro"),null))
                .CreateBranch(new(110, "John"))
                    .CreateBranch(new(120, "Chris"))
                        .Add(new(1110, "Eric"))
                        .CreateBranch(new(1120, "Ashley"))
                            .Add(new(1111, "Emily"))
                        .CloseBranch()
                    .CloseBranch()
                .CloseBranch();
            foreach (Node<Employee> em in tr.Nodes)
            {
                Display(tr.Root, 0);
            }
            Console.WriteLine("=============================");

            Random rnd = new Random(); //000 - 999
            int randomEmployee = rnd.Next(100, 1125);

            while (randomEmployee % 100 == 0 || randomEmployee % 10 == 0)
            {
                randomEmployee = rnd.Next(100, 1125);
            }
            randomEmployee = 1111;

            Node<Employee> search = tr.Find(tr.Root, x => x.Data.EmpNo == randomEmployee);
            Console.WriteLine($"Top level for {search.Data.Name} is {search.Parent.Parent.Data.Name}");
            Console.WriteLine($"Second level {search.Data.Name} is {search.Parent.Data.Name}");
        }

        static void Display(Node<Employee> node, int level)
        {
            Console.WriteLine($"{new string(' ',level * 4)}{node.Data.Name}");
            level++;
            foreach (Node<Employee> n in node.Children)
            {
                Display(n, level);
            }
        }
    }
}