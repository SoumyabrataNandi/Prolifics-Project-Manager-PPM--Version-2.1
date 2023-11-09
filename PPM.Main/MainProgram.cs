using System;
using PPM.Ui.Consoles;

namespace PPM.Main
{
    public class MainProgram
    {
        static ProjectModuleManager projectModuleManager = new();
        static EmployeeModuleManager employeeModuleManager = new();
        static RoleModuleManager roleModuleManager = new();
        
        static void Main(string[] args)
        {
             // Giving Welcome Message
            Console.WriteLine("Welcome to Prolifics Project Manager(PPM)");

            // Use try-catch-finaly block for exception handling
            try
            {
                // Creating menu with infinite while loop
                while (true)
                {
                    // All menu options
                    Console.WriteLine();
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>> Menu <<<<<<<<<<<<<<<<<<<<<<<");
                    Console.WriteLine(">>                                               <<");
                    Console.WriteLine(">>             1. Project Module                 <<");
                    Console.WriteLine(">>             2. Employee Module                <<");
                    Console.WriteLine(">>             3. Role Module                    <<");
                    Console.WriteLine(">>             4. Exit                           <<");
                    Console.WriteLine(">>                                               <<");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<");
                    Console.WriteLine();

                    // Taking input from user
                    Console.WriteLine("Enter Your Menu Choice Option:");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice < 0)
                    {
                        // Exception expObj = new Exception("Choice should not be negative");
                        throw new Exception("Choice should not be negative");
                    }

                    switch (choice)
                    {
                        case 1:
                            projectModuleManager.ProjectModule();
                            break;

                        case 2:
                            employeeModuleManager.EmployeeModule();
                            break;

                        case 3:
                            roleModuleManager.RoleModule();
                            break;

                        case 4:
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
            }
            catch (FormatException exp)
            {
                System.Console.WriteLine("Exception ocurred in the Application. Check the exception details below:");
                System.Console.WriteLine("Message  : {0}.",exp.Message);
                System.Console.WriteLine();
            }
            catch (Exception exp)
            {
                System.Console.WriteLine("Exception ocurred in the Application. Check the exception details below:");
                System.Console.WriteLine("Message : {0}",exp.Message);
                System.Console.WriteLine();
            }
            // If any exception occurs or not this finally block will be executed any show this message before exit from application
            finally
            {
                System.Console.WriteLine("Thank You for using Prolifics Project Manager(PPM)");
            }
        }
    }
}