using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        #region
        //New Cashier Does Not Know About Space or Shift

        //Some new cashiers started to work at your restaurant.

        //They are good at taking orders, but they don't know how to capitalize words, or use a space bar!

        //All the orders they create look something like this:

        //"milkshakepizzachickenfriescokeburgerpizzasandwichmilkshakepizza"

        //The kitchen staff are threatening to quit, because of how difficult it is to read the orders.

        //Their preference is to get the orders as a nice clean string with spaces and capitals like so:

        //"Burger Fries Chicken Pizza Pizza Pizza Sandwich Milkshake Milkshake Coke"

        //The kitchen staff expect the items to be in the same order as they appear in the menu.

        //The menu items are fairly simple, there is no overlap in the names of the items:

        //1.Burger
        //2.Fries
        //3.Chicken
        //4.Pizza
        //5.Sandwich
        //6.Onionrings
        //7.Milkshake
        //8.Coke
        #endregion

        string input = Console.ReadLine();

        string output = GetOrder(input);
        Console.WriteLine(output);
    }

    public static string GetOrder(string input)
    {
        var menu = new List<string>() { "Burger", "Fries", "Chicken", "Pizza", "Sandwich", "Onionrings", "Milkshake", "Coke" };
        var occurances = new int[8];

        for (int i = 0; i < 8; i++) // cycle through as each word and occurance are on the same index
        {
            string word = menu[i];
            occurances[i] = Regex.Matches(input, word.ToLower()).Count;
        }

        var listOfOrder = new List<string>(); // put the words in the list x occurances
        for (int index = 0; index < 8; index++)
        {
            bool atleastOnce = occurances[index] > 0;
            if (atleastOnce)
            {
                for (int occured = 0; occured < occurances[index]; occured++)
                {
                    listOfOrder.Add(menu[index]);
                }
            }
        }

        string order = string.Join(" ", listOfOrder);
        return order;
    }
}