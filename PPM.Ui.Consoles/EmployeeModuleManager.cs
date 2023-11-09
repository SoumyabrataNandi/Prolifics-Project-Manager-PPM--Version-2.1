using System;
using PPM.Domain;
using PPM.Model;

namespace PPM.Ui.Consoles
{
    public class EmployeeModuleManager
    {
        static EmployeeRepo employeeRepo = new();
        static Employee employee = new();
        static ValidationCheck validationCheck = new();

        public void EmployeeModule()
        {
            while (true)
            {
                // Employee menu options
                Console.WriteLine();
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>> Employee Menu <<<<<<<<<<<<<<<<<<<<<<<");
                Console.WriteLine(">>                                                        <<");
                Console.WriteLine(">>             1. Add Employee                            <<");
                Console.WriteLine(">>             2. List of All Employees                   <<");
                Console.WriteLine(">>             3. Get Employee by Id                      <<");
                Console.WriteLine(">>             4. Delete Employee                         <<");
                Console.WriteLine(">>             5. Return to Main Menu                     <<");
                Console.WriteLine(">>                                                        <<");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                Console.WriteLine();

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
                        Console.Clear();
                        Console.WriteLine("Enter Employee Id: ");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        if (validationCheck.IsEmployeeIdValid(employeeId) == true)
                        {
                            Console.WriteLine("Employee Id is Already Present....");
                            return;
                        }
                        employee.EmployeeId = employeeId;
                        Console.WriteLine("Enter Employee First Name: ");
                        employee.EmployeeFirstName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Last Name: ");
                        employee.EmployeeLastName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Email: ");
                        string employeeEmail = Console.ReadLine()!;
                        if (!validationCheck.IsValidEmail(employeeEmail))
                        {
                            Console.WriteLine("...Invalid Email Format... Please Enter Valid Email...");
                            return;
                        }
                        employee.EmployeeEmail = employeeEmail;
                        Console.WriteLine("Enter Employee Mobile Number: ");
                        long employeeMobileNumber = Convert.ToInt64(Console.ReadLine());
                        if (!validationCheck.IsValidMobileNumber(employeeMobileNumber.ToString()))
                        {
                            Console.WriteLine("...Invalid Mobile Number Format... Please Enter Valid Mobile Number...");
                            return;
                        }
                        employee.EmployeeMobileNumber = employeeMobileNumber;
                        Console.WriteLine("Enter Employee Address: ");
                        employee.EmployeeAddress = Console.ReadLine();
                        Console.WriteLine("Enter Role Id: ");
                        int employeeRoleId = Convert.ToInt32(Console.ReadLine());
                        if (!validationCheck.IsValidRole(employeeRoleId))
                        {
                            Console.WriteLine("...Invalid Role Id... Please Enter Valid Role Id...");
                            return;
                        }
                        employee.EmployeeRoleId = employeeRoleId;

                        // Add all data into List
                        employeeRepo.AddEmployee(employee);
                        break;

                    case 2:
                        Console.Clear();
                        employeeRepo.ListAllEmployees();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter Employee Id:");
                        int employeeIdforFind = Convert.ToInt32(Console.ReadLine());

                        employeeRepo.GetEmployee(employeeIdforFind);
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter Employee Id:");
                        int employeeIdforDelete = Convert.ToInt32(Console.ReadLine());

                        employeeRepo.DeleteEmployee(employeeIdforDelete);
                        break;

                    case 5:
                        return;

                    default:
                        System.Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }
    }
}