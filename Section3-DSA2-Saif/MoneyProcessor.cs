using Section3_DSA2_Saif.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_DSA2_Saif
{
    internal class MoneyProcessor
    {
        private readonly List<double> Denominations = new() { 2.0, 1.0, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };

        public void PrintAllWays()
        {
            Console.Write("Enter an amount between 0.01 and 5.00: ");
            string userInput = Console.ReadLine();

            if (!decimal.TryParse(userInput, out decimal inputAmount) || inputAmount < 0.01m || inputAmount > 5.00m)
            {
                Console.WriteLine("Invalid amount. Please enter a valid amount between 0.01 and 5.00");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                return;
            }

            var combinations = GenerateAllCombinations(inputAmount);

            DisplayCombinations(inputAmount, combinations);

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        private static List<List<decimal>> GenerateAllCombinations(decimal targetAmount)
        {
            int totalAmount = (int)(targetAmount * 100);

            int[] denominations = new int[] { 200, 100, 50, 20, 10, 5, 2, 1 }; // Denominations in cents

            List<List<int>> combinations = GetAllCombinations(totalAmount, denominations);

            return combinations.Select(combination => combination.Select(coin => coin / 100.0m).ToList()).ToList();
        }

        private static void DisplayCombinations(decimal inputAmount, List<List<decimal>> combinations)
        {
            Console.WriteLine($"All possible combinations for {inputAmount:C2} using not more than 10 coins:");

            foreach (var combination in combinations)
            {
                foreach (var coin in combination)
                {
                    Console.Write($"{coin:C2} ");
                }
                Console.WriteLine();
            }
        }

        private static List<List<int>> GetAllCombinations(int targetAmount, int[] coins)
        {
            List<List<int>> result = new();
            Stack<CombinationInfo> stack = new();
            stack.Push(new CombinationInfo(0, new List<int>(), targetAmount));

            while (stack.Count > 0)
            {
                CombinationInfo current = stack.Pop();

                if (current.RemainingAmount < 0 || current.CurrentCombination.Count > 10)
                    continue;

                if (current.RemainingAmount == 0)
                {
                    result.Add(new List<int>(current.CurrentCombination));
                    continue;
                }

                for (int i = current.StartIdx; i < coins.Length; i++)
                {
                    List<int> newCombination = new(current.CurrentCombination)
                    {
                        coins[i]
                    };
                    stack.Push(new CombinationInfo(i, newCombination, current.RemainingAmount - coins[i]));
                }
            }

            return result;
        }

        public void FindLeastAmount()
        {
            Console.Write("Enter the amount between 0.01 and 5.00: ");
            string userInput = Console.ReadLine();

            if (!double.TryParse(userInput, out double inputAmount) || inputAmount < 0.01 || inputAmount > 5.00)
            {
                Console.WriteLine("Invalid amount. Please enter a valid amount between 0.01 and 5.00");
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                return;
            }

            List<decimal> coins = GetFewestCoins(inputAmount);

            DisplayFewestCoins(inputAmount, coins);

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        private List<decimal> GetFewestCoins(double amount)
        {
            Denominations.Sort((a, b) => b.CompareTo(a));

            List<decimal> coins = new();
            int coinsCount = 0;

            foreach (var coin in Denominations)
            {
                while (amount >= coin && coinsCount < 10)
                {
                    coins.Add((decimal)coin);
                    amount -= coin;
                    amount = Math.Round(amount, 2);
                    coinsCount++;
                }
            }

            return coins;
        }

        private static void DisplayFewestCoins(double inputAmount, List<decimal> coins)
        {
            Console.WriteLine($"The combination with the fewest coins for {inputAmount:C2} is:");
            foreach (var coin in coins)
            {
                Console.Write($"{coin:C2} ");
            }
            Console.WriteLine();
        }
    }
}
