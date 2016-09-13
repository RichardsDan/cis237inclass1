using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee myEmployee = new Employee();
            myEmployee.FirstName = "Daniel";
            myEmployee.LastName = "Richards";
            myEmployee.WeeklySalary = 2048.34m;

            Console.WriteLine(myEmployee.FirstName);
            Console.WriteLine(myEmployee);

            Employee[] employees = new Employee[10];

            employees[0] = new Employee("Frank", "Fontaine", 53.00m);
            employees[1] = new Employee("Corvo", "Attano", 1280.00m);
            employees[2] = new Employee("Emily", "Kaldwin", 3840.00m);
            employees[3] = new Employee("Booker", "Dewitt", 453.00m);
            employees[4] = new Employee("Andrew", "Ryan", 4633.00m);

            foreach (Employee employee in employees)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee.ToString() + " " + employee.YearlySalary());
                }
            }

            UserInterface ui = new UserInterface();

            int choice = ui.GetUserInput();

            while (choice != 2)
            {
                if (choice == 1)
                {
                    string allOutput = "";

                    foreach (Employee employee in employees)
                    {
                        if (employee != null)
                        {
                            allOutput += employee.ToString() + " " +
                                employee.YearlySalary() +
                                Environment.NewLine;
                        }
                    }
                    ui.PrintAllOutput(allOutput);
                }
                choice = ui.GetUserInput();
            }
        }
    }
}
