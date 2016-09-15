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
            // Declaring a variable of type Employee (Which is a class) and
            // instantiating a new instance of Employee and assigning it to the variable
            // Using the NEW keyword means that memory will get allocated on the Heap for that class
            Employee myEmployee = new Employee();

            // Use the properties to assign values
            myEmployee.FirstName = "Daniel";
            myEmployee.LastName = "Richards";
            myEmployee.WeeklySalary = 2048.34m;

            // Output the first name of the employee
            Console.WriteLine(myEmployee.FirstName);
            // Output the entire employee, calling the ToString method by implicitly
            Console.WriteLine(myEmployee);

            // Create an array of type Employee to hold a bunch of Employees
            Employee[] employees = new Employee[10];

            // Assign values to the array. Each spot needs to contain an instance of an Employee
            employees[0] = new Employee("Frank", "Fontaine", 53.00m);
            employees[1] = new Employee("Corvo", "Attano", 1280.00m);
            employees[2] = new Employee("Emily", "Kaldwin", 3840.00m);
            employees[3] = new Employee("Booker", "Dewitt", 453.00m);
            employees[4] = new Employee("Andrew", "Ryan", 4633.00m);

            // A foreach loop. It is useful for doing a collection of objects
            // Each object in the array 'employees' will get assigned to the local
            // variable 'employee' inside the loop
            foreach (Employee employee in employees)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee.ToString() + " " + employee.YearlySalary());
                }
            }

            // Instantiate a new UI class
            UserInterface ui = new UserInterface();

            // Get the user input from the UI class
            int choice = ui.GetUserInput();

            // While the choice entered is not 2, we will loop to 
            // continue to get the next choice of what they want to do.
            while (choice != 2)
            {
                if (choice == 1)
                {
                    // Create a string to concat the output
                    string allOutput = "";

                    // Loop through all the employees just like above only instead of
                    // writing out the employees, we are concatenating them together.
                    foreach (Employee employee in employees)
                    {
                        if (employee != null)
                        {
                            allOutput += employee.ToString() + " " +
                                employee.YearlySalary() +
                                Environment.NewLine;
                        }
                    }
                    // Once the concat is done, have the UI class print out the result
                    ui.PrintAllOutput(allOutput);
                }
                // Get the next choice from the user
                choice = ui.GetUserInput();
            }
        }
    }
}
