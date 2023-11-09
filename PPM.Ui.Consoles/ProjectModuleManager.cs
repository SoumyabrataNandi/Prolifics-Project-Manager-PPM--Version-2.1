using System;
using PPM.Domain;


namespace PPM.Ui.Consoles
{
    public class ProjectModuleManager
    {
        static ProjectRepo projectRepo = new();

        static ValidationCheck validationCheck = new();

        public void ProjectModule()
        {
            while (true)
            {
                // Project menu options
                Console.WriteLine();
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>> Project Menu <<<<<<<<<<<<<<<<<<<<<<<");
                Console.WriteLine(">>                                                       <<");
                Console.WriteLine(">>             1. Add Project                            <<");
                Console.WriteLine(">>             2. List of All Projects                   <<");
                Console.WriteLine(">>             3. Get Project by Id                      <<");
                Console.WriteLine(">>             4. Delete Project                         <<");
                Console.WriteLine(">>             5. Return to Main Menu                    <<");
                Console.WriteLine(">>                                                       <<");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
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
                        Console.WriteLine("Enter Project Id: ");
                        int projectId = Convert.ToInt32(Console.ReadLine());
                        if (validationCheck.IsProjectIdValid(projectId) == true)
                        {
                            Console.WriteLine("Project Id is Already Present.....");
                            return;
                        }
                        ProjectRepo.project.ProjectId = projectId;
                        Console.WriteLine("Enter Project Name: ");
                        ProjectRepo.project.ProjectName = Console.ReadLine();
                        Console.WriteLine("Enter Project Start Date (YYYY-MM-DD):");
                        DateOnly projectStartDate = DateOnly.Parse(Console.ReadLine()!);

                        if (!validationCheck.IsValidDate(projectStartDate.ToString()))
                        {
                            Console.WriteLine("Invalid Date Format");
                            return;
                        }

                        Console.WriteLine("Enter Project End Date (YYYY-MM-DD):");
                        DateOnly projectEndDate = DateOnly.Parse(Console.ReadLine()!);

                        if (!validationCheck.IsValidDate(projectEndDate.ToString()))
                        {
                            Console.WriteLine("Invalid Date Format");
                            return;
                        }

                        if (projectStartDate < projectEndDate)
                        {
                            Console.WriteLine("  End Date Should Not Be Greater Than Start Date   ");
                        }
                        ProjectRepo.project.ProjectStartDate = projectStartDate;
                        ProjectRepo.project.ProjectStartDate = projectEndDate;

                        Console.WriteLine("Do You Want AddEmployee to This Project...");
                        Console.WriteLine("Press 1...");
                        Console.WriteLine("Press Any Other Number To Continue...");
                        int wantToAddOrNot = Convert.ToInt32(Console.ReadLine());

                        if (wantToAddOrNot == 1)
                        {
                            Console.WriteLine("How many Employee You Want To Add This Project:-");
                            int employeeAddToProjectCount = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < employeeAddToProjectCount; i++)
                            {
                                // Prompt user to enter employee ID
                                Console.WriteLine("Enter Employee Id ");
                                int employeeId = Convert.ToInt32(Console.ReadLine());

                                projectRepo.AddEmployeeToProject(employeeId);
                            }
                        }
                        // Enhance Ment Pending add Employee when add project with Role
                        projectRepo.AddProject(ProjectRepo.project);
                        break;

                    case 2:
                        Console.Clear();
                        projectRepo.ListAllProjects();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter Project Id:");
                        int projectIdforFind = Convert.ToInt32(Console.ReadLine());

                        projectRepo.GetProject(projectIdforFind);
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter Project Id:");
                        int projectIdforDelete = Convert.ToInt32(Console.ReadLine());

                        projectRepo.DeleteProject(projectIdforDelete);
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