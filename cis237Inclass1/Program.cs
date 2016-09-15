using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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



            // Use the CSVProcessor method that we wrote into main to load the 
            // Employees from the csv file
            ImportCSV("employees.csv", employees);




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

        static bool ImportCSV(string pathToCsvFile, Employee[] employees)
        {
            // Declare a variable for the stream reader. Not going to instantiate it yet.
            StreamReader streamReader = null;

            // Start a try since the path to the file could be incorrect, and thus
            // throw an exception
            try
            {
                // Declare a string for each line we will read in.
                string line;

                // Instantiate the streamreader. If the path to file is incorrect it will
                // throw an exception that we can catch
                streamReader = new StreamReader(pathToCsvFile);

                // Set up a counter that is as yet unused
                int counter = 0;

                // While there is a line to read, read the line and put it in the line var
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Call the process line method and send over the read in line,
                    // the employees array (which is passed by reference automatically),
                    // and the counter, which will be used as the index for the array.
                    // We are also incrementing the counter after we send it in with the ++ operator.
                    ProcessLine(line, employees, counter++);
                }

                // All reads are successful, return true
                return true;
            }
            catch (Exception e)
            {
                // Output the exception string, and the stack trace
                // The stack trace is all of the method calls that lead to 
                // Where the exception occured.
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);

                // Return false, reading failed
                return false;
            }
            // Used to ensure the code within it gets executed regardless of whether the
            // Try succeeds or the catch gets executed
            finally
            {
                // Check to make sure the streamreader is instantiated before
                // trying to call a method on it.
                if (streamReader != null)
                {
                    // Close the streamReader
                    streamReader.Close();
                }
            }
        }

        static void ProcessLine(string line, Employee[] employees, int index)
        {
            // Declare a string array and assign the split line to it.
            string[] parts = line.Split(',');

            // Assign the parts to local variables that mean something
            string firstName = parts[0];
            string lastName = parts[1];
            decimal salary = decimal.Parse(parts[2]);
            
            // Use the variables to instantiate a new Employee and assign it to 
            // the spot in the employees array indexed by the index that was passed in
            employees[index] = new Employee(firstName, lastName, salary);
        }
    }
}
