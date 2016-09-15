using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class UserInterface
    {
        // There are no backing fields because we don't need any
        // There are no properties because we don't have any backing fields
        // There are also no constructors, we will just use the default that is automatically provided to us.

        // This class essentially becomes a collection of methods that do work.

        public int GetUserInput()
        {
            // Call the printMenu method that is private to the class
            this.PrintMenu();

            // Get input from the console.
            string input = Console.ReadLine();

            // Continue to loop while the input is not a valid choice
            while(input != "1" && input != "2")
            {
                // Since it is not valid, output a message saying so
                Console.WriteLine("That is not a valid entry");
                Console.WriteLine("Please make a valid choice");
                Console.WriteLine();

                // Redisplay the menu in case the user forgot what they could do.
                this.PrintMenu();

                // re-get the input from the user.
                input = Console.ReadLine();
            }

            // At this point, the input is valid, so we can return the parse of it.
            return Int32.Parse(input);
        }

        public void PrintAllOutput(string allOutput)
        {
            Console.WriteLine(allOutput);
        }
        private void PrintMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Print list");
            Console.WriteLine("2. Exit");
        }
    }
}
