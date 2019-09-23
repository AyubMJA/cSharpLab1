/// I, Ayub Ali, 000354446 certify that this material is my original work. No other person's work has been used without due acknowledgement.
/// Program: Employee Sorting program.
///
/// 
/// AUTHOR: Ayub Ali
/// Student ID: 000354446
/// DATE: 2019-09-20
/// 
/// 
///  PURPOSE: This application takes data from employee.text file. Creates an array of employee objects and displays a menu
///  to the user to decide how they want to display the information in the console
///
/// Sources used:
/// For reference on sorting algorithum: 
/// 1. https://www.geeksforgeeks.org/selection-sort/
/// 2. https://www.youtube.com/watch?v=nDKyoOtJxzY
/// 3. https://elearn.mohawkcollege.ca/d2l/le/content/525775/viewContent/4741702/View
/// 4. https://github.com/StoychoMihaylov/SortAlgorithms/blob/master/Algoritms/SelectionSort/SelectionSort.cs
/// 5. https://csharp.2000things.com/tag/utf-16/
///
///


using System;
using System.IO;


namespace Lab1
{
    class Program
    {
        static Employee[] employees = new Employee[100]; // This is an array that holds employee objects.
        static bool loopControl = true; // This helps the loop keep going until turned false its a flag.


        /// <summary>
        /// This is the main program where all the sorting and the menu printing happens.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string mainMenuInput; // mainMenuInput stores user input from the command line.
            int userChoice; // This is going to be user choice value stored. However it is convert from string.

            readData(); // readData() method call.


            //While loop to continue display  mainMenu() method and parse data to the sort() method.
            while (loopControl)
            {
                mainMenuInput = mainMenu();
                if (int.TryParse(mainMenuInput, out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            //This sort employee names in (ascending order).
                            sort(userChoice);
                            break;
                        case 2:
                            //This sort employee numbers in (ascending order).
                            sort(userChoice);
                            break;
                        case 3:
                            //This sort employee pay rate in (descending order).
                            sort(userChoice);
                            break;
                        case 4:
                            //This sort employee hours in (descending order).
                            sort(userChoice);
                            break;
                        case 5:
                            //This sort employee gross pay in (descending order).
                            sort(userChoice);
                            break;
                        case 6:
                            //This exists the program.
                            loopControl = false;
                            break;
                        default:
                            Console.WriteLine("Invalid user input try again!");
                            break;
                    }
                }
            }

            
        }

        // ======================== Menu ============================= //

        /// <summary>
        /// This is the mainMenu() method that continually displaces the information to the user on screen.
        /// </summary>
        /// <returns></returns>
        private static string mainMenu()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("============ Employee Record ==========");
            Console.WriteLine("=======================================");

            Console.WriteLine("      1. Sort by Employee Name");
            Console.WriteLine("      2. Sort by Employee Number");
            Console.WriteLine("      3. Sort by Employee Pay Rate");
            Console.WriteLine("      4. Sort by Employee hours");
            Console.WriteLine("      5. Sort by Employee Gross Pay");
            Console.WriteLine("      6. Exit");

            Console.WriteLine("\n     Pick one choice above!");

            return Console.ReadLine();
        }

        //====================== Read Method ========================//

        /// <summary>
        /// The readData() method is responsible for reading the employee.csv file and parsing the data found to the employee 
        /// array for later use.
        /// </summary>
        private static void readData()
        {
            
            string line = ""; //This store the line on the employees.csv
            int lineNumber = 0; // Keeps cout of how many lines it read.

            try
            {
                StreamReader fileInput = new StreamReader("employees.csv");

                while (!fileInput.EndOfStream)
                {
                    line = fileInput.ReadLine();
                    String[] parts = line.Split(',');
                    employees[lineNumber] = new Employee(parts[0], int.Parse(parts[1]), decimal.Parse(parts[2]), double.Parse(parts[3]));
                    lineNumber++;
                }
                fileInput.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File Not Found employees.csv"+ ex.Message);
                return;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error on line {lineNumber + 1} reading line {line} - {ex.Message}");
                return;
            }

        }


        //===================== Sorting =============================//
        /// <summary>
        /// variable choice is the value grabbed once the user picked their option.
        /// The Sort() method sorts the information in the console from ascending and decending order.
        /// </summary>
        /// <param name="choice"></param>
       private static void sort(int choice)
        {
            Console.Clear();

            for (int i = 0; i < employees.Length; i++)
            {
                for (int j = i++; j> 0; j--)
                {
                    if (employees[j] != null)
                    {
                        switch (choice)
                        {
                            case 1: // Sort by Employee Name (ascending)
                                if (employees[j - 1].GetName().CompareTo(employees[j].GetName()) > 0)
                                {
                                    var t = employees[j - 1];
                                    employees[j - 1] = employees[j];
                                    employees[j] = t;
                                }
                                break;
                            case 2: // Sort by Employee Number (ascending)
                                if (employees[j - 1].GetNumber().CompareTo(employees[j].GetNumber()) > 0)
                                {
                                    var t = employees[j - 1];
                                    employees[j - 1] = employees[j];
                                    employees[j] = t;
                                }
                                    break;
                            case 3: // Sort by Employee Pay Rate (descending)
                                if (employees[j - 1].GetRate().CompareTo(employees[j].GetRate()) < 0)
                                {
                                    var t = employees[j - 1];
                                    employees[j - 1] = employees[j];
                                    employees[j] = t;
                                }
                                    break;
                            case 4: // Sort by Employee Hours (descending)
                                if (employees[j - 1].GetHours().CompareTo(employees[j].GetHours()) < 0)
                                {
                                    var t = employees[j - 1];
                                    employees[j - 1] = employees[j];
                                    employees[j] = t;
                                }
                                    break;
                            case 5: // Sort by Employee Gross Pay (descending)
                                if (employees[j - 1].GetGross().CompareTo(employees[j].GetGross()) < 0)
                                {
                                    var t = employees[j - 1];
                                    employees[j - 1] = employees[j];
                                    employees[j] = t;
                                }
                                    break;
                            default:
                                Console.WriteLine("invalid input");
                                break;
                        }
                    }
                }
            }
            printOutput();
            
        }

       

        //======================= print output ===============================//
        /// <summary>
        /// printOutput() method prints the information on the console. In a table format.
        /// </summary>
        private static void printOutput()
        {
            Console.WriteLine("{0, -15}  {1:D5}  {2,6:C} {3:#0.00}  {4,9:C}\n", "  Name", "  Number", " Rate", "    Hours", " Gross");
            foreach (Employee x in employees)
            {
                if (x != null)
                {
                    x.printEmploy();
                }
            }
        }

    }
}
