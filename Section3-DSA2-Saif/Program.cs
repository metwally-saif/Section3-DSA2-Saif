using Section3_DSA2_Saif;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new();

        while (true)
        {
            Console.Clear();
            menu.ShowMenu();

            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Input cannot be empty");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                continue;
            }

            if (!menu.HandleInput(userInput))
            {
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
            }
        }
    }
}