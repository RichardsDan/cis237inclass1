using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class UserInterface
    {
        public int GetUserInput()
        {
            this.PrintMenu();

            string input = Console.ReadLine();

            while(input != "1" && input != "2")
            {
                Console.WriteLine("That is not a valid entry");
                Console.WriteLine("Please make a valid choice");
                Console.WriteLine();

                this.PrintMenu();

                input = Console.ReadLine();
            }

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
