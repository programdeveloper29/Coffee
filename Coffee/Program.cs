using System;

namespace Coffee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Loop for multiple orders
            char anotherOrder;
            do
            {
                Console.Write("Enter Beans Type: ");
                string beans = Console.ReadLine();

                Console.Write("Do you want milk? (y/n): ");
                char milkChoice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                bool withMilk = milkChoice == 'y';

                // Create a new Coffee object
                Coffee cup = new Coffee(beans, 0, withMilk);

                char changeSugar;
                do
                {
                    Console.Write("Add sugar (0-5): ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int sugar))
                    {
                        cup.AddSugar(sugar);
                        Console.WriteLine("Current Cup: " + cup.Details());
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                    Console.Write("Do you want to change sugar? (y/n): ");
                    changeSugar = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                } while (changeSugar == 'y');

                Console.Write("Do you want another order? (y/n): ");
                anotherOrder = Console.ReadKey().KeyChar;
                Console.WriteLine();

            } while (anotherOrder == 'y');

            Console.WriteLine("Thanks for your orders!");
            Console.ReadKey();
        }
    }

    public class Coffee
    {
        private string _beansType;
        private int _sugar;
        private bool _withMilk;

        // Properties (Read-only for BeansType and WithMilk)
        public string BeansType => _beansType;
        public bool WithMilk => _withMilk;
        public int Sugar => _sugar;

        // Constructor
        public Coffee(string beansType, int sugar, bool withMilk)
        {
            if (string.IsNullOrWhiteSpace(beansType))
                throw new ArgumentException("Beans type cannot be empty.");

            if (sugar < 0 || sugar > 5)
                throw new ArgumentException("Sugar must be between 0 and 5.");

            _beansType = beansType;
            _sugar = sugar;
            _withMilk = withMilk;
        }

        // Method to add sugar with validation
        public void AddSugar(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Sugar cannot be negative.");
                return;
            }

            if (_sugar + amount > 5)
            {
                Console.WriteLine("Maximum sugar allowed is 5 spoons.");
                return;
            }

            _sugar += amount;
        }

        // Get coffee details
        public string Details()
        {
            return $"Bean Type: {_beansType}, Sugar: {_sugar}, " +
                   $"{(_withMilk ? "With Milk" : "Without Milk")}";
        }
    }
}