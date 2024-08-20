
namespace Trees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeMethods treeMethods = new();
            ConsoleKeyInfo button;
            List<ConsoleKey> avaliableButtons = new() 
            { 
                ConsoleKey.NumPad0, 
                ConsoleKey.D0, 
                ConsoleKey.NumPad1, 
                ConsoleKey.D1 
            };

            treeMethods.RunEntireProgram();

            do
            {
                Console.WriteLine("Press 0 - start the program from the beginning\n" +
                                  "Press 1 - to find another employee by salary value");

                button = Console.ReadKey();

                if (button.Key == ConsoleKey.NumPad0 || button.Key == ConsoleKey.D0)
                {
                    Console.WriteLine();
                    treeMethods.RunEntireProgram();
                }
                else if (button.Key == ConsoleKey.NumPad1 || button.Key == ConsoleKey.D1)
                {
                    treeMethods.FindNumber(treeMethods.OriginRoot);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Unknown command! End of programm!");
                }
            }
            while (avaliableButtons.Contains(button.Key));
        }
    }
}
