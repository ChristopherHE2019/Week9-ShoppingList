using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = @"D:\!Projekteerimine\Mincrosoft visualStudios\Source\Samples\MyShoppingList";
            string fileName = @"\\MyShoppingList.txt";

            if (!Directory.Exists($"{fileLocation}") && !File.Exists($"{fileLocation}{fileName}"))
            {
                Directory.CreateDirectory($"{fileLocation}");
                File.Create($"{fileLocation}{fileName}");
            }

            string[] arrayFromFile = File.ReadAllLines($"{fileLocation}{fileName}");
            List<string> myShoppingList = arrayFromFile.ToList<string>();

            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Would you like to add an item to the shopping list? Y/N:");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    Console.WriteLine("Enter your item:");
                    string userItem = Console.ReadLine();
                    myShoppingList.Add(userItem);
                }
                else
                {
                    loopActive = false;
                    Console.WriteLine("Take care!");
                }
            }

            Console.Clear();

            foreach (string item in myShoppingList)
            {
                Console.WriteLine($"Your item: {item}");
            }

            File.WriteAllLines($"{fileLocation}{fileName}", myShoppingList);
        }
    }
}
