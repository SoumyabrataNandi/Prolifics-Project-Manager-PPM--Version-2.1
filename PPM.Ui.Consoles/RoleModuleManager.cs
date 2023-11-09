using System;
using PPM.Domain;

namespace PPM.Ui.Consoles
{
    public class RoleModuleManager
    {
        static RoleRepo roleRepo = new();

        static ValidationCheck validationCheck = new();
        public void RoleModule()
        {
            while (true)
            {
                // Role menu options
                Console.WriteLine();
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>> Role Menu <<<<<<<<<<<<<<<<<<<<<<<");
                Console.WriteLine(">>                                                    <<");
                Console.WriteLine(">>             1. Add Role                            <<");
                Console.WriteLine(">>             2. List of All Roles                   <<");
                Console.WriteLine(">>             3. Get Role by Id                      <<");
                Console.WriteLine(">>             4. Delete Role                         <<");
                Console.WriteLine(">>             5. Return to Main Menu                 <<");
                Console.WriteLine(">>                                                    <<");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<<");
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
                        Console.WriteLine("Enter Role Id:");
                        int roleId = Convert.ToInt32(Console.ReadLine());
                        if (validationCheck.IsRoleIdValid(roleId) == true)
                        {
                            Console.WriteLine("Project Id is Already Present.....");
                            return;
                        }
                        RoleRepo.role.RoleId = roleId;
                        System.Console.WriteLine("Enter Role Name:");
                        RoleRepo.role.RoleName = Console.ReadLine()!;

                        roleRepo.AddRole(RoleRepo.role);
                        break;

                    case 2:
                        Console.Clear();
                        roleRepo.ListAllRoles();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter Role Id:");
                        int roleIdforFind = Convert.ToInt32(Console.ReadLine());

                        roleRepo.GetRole(roleIdforFind);
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter Role Id:");
                        int roleIdforDelete = Convert.ToInt32(Console.ReadLine());

                        roleRepo.DeleteRole(roleIdforDelete);
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