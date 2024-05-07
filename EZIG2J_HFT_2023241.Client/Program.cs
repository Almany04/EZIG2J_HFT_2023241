
using ConsoleTools;
using EZIG2J_HFT_2023241.Logic.Classes;
using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using System;
using System.Linq;

namespace EZIG2J_HFT_2023241.Client
{
    internal class Program
    {
        static EmployeeLogic employeeLogic;
        static DepartmentLogic departmentLogic;
        static ProjectLogic projectLogic;
        static ProjectAssignmentLogic projectassigmentLogic;

        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Employee")
            {
                var items = employeeLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.EmployeeId + "\t" + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void List1(string entity)
        {
            if (entity == "Department")
            {
                var items = departmentLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.DepartmentId + "\t" + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void List2(string entity)
        {
            if (entity == "ProjectAssignment")
            {
                var items = projectassigmentLogic.ReadAll();
                Console.WriteLine("Id" + "\t");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ProjectAssignmentId);
                }
            }
            Console.ReadLine();
        }
        static void List3(string entity)
        {
            if (entity == "Project")
            {
                var items = projectLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ProjectId + "\t" + item.Title);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var ctx = new EmployeeDbContext();

            var employeeRepo = new EmployeeRepository(ctx);
            var departRepo = new DepartmentRepository(ctx);
            var proassiRepo = new ProjectAssignRepository(ctx);
            var projectRepo = new ProjectRepository(ctx);

            employeeLogic = new EmployeeLogic(employeeRepo);
            departmentLogic = new DepartmentLogic(departRepo);
            projectassigmentLogic = new ProjectAssignmentLogic(proassiRepo);
            projectLogic = new ProjectLogic(projectRepo);

            var employeeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Employee"))
                .Add("Create", () => Create("Employee"))
                .Add("Delete", () => Delete("Employee"))
                .Add("Update", () => Update("Employee"))
                .Add("Exit", ConsoleMenu.Close);

            var departmentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List1("Department"))
                .Add("Create", () => Create("Department"))
                .Add("Delete", () => Delete("Department"))
                .Add("Update", () => Update("Department"))
                .Add("Exit", ConsoleMenu.Close);

            var projectassignSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List2("ProjectAssignment"))
                .Add("Create", () => Create("ProjectAssignment"))
                .Add("Delete", () => Delete("ProjectAssignment"))
                .Add("Update", () => Update("ProjectAssignment"))
                .Add("Exit", ConsoleMenu.Close);

            var projectSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List3("Project"))
                .Add("Create", () => Create("Project"))
                .Add("Delete", () => Delete("Project"))
                .Add("Update", () => Update("Project"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Employee", () => employeeSubMenu.Show())
                .Add("Department", () => departmentSubMenu.Show())
                .Add("ProjectAssignment", () => projectassignSubMenu.Show())
                .Add("Project", () => projectSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
