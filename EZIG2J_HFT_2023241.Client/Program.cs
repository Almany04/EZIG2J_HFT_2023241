
using ConsoleTools;
using EZIG2J_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace EZIG2J_HFT_2023241.Client
{
   internal class Program
    {

        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Employee")
            {
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();
                rest.Post(new Employee() { Name = name }, "Employee");
            }else if(entity == "Department")
            {
                Console.Write("Enter Department Name: ");
                string name = Console.ReadLine();
                rest.Post(new Department() { Name = name }, "Department");
            }
            else if (entity == "Project")
            {
                Console.Write("Enter Project Title: ");
                string name = Console.ReadLine();
                rest.Post(new Project() { Title = name }, "Project");
            }
            else if (entity == "ProjectAssignment")
            {
                Console.Write("Enter ProjectAssignment Id: ");
                string id = Console.ReadLine();
                int idvalue = int.Parse(id);
                rest.Post(new ProjectAssignment() { ProjectAssignmentId = idvalue }, "ProjectAssignment");
            }
        }
        static void List(string entity)
        {
            if (entity == "Employee")
            {
                List<Employee> employees = rest.Get<Employee>("Employee");
                foreach (var item in employees)
                {
                    Console.WriteLine(item.EmployeeId + ": " + item.Name);
                }
            } else if (entity == "Department")
            {
                List<Department> departments = rest.Get<Department>("Department");
                foreach (var item in departments)
                {
                    Console.WriteLine(item.DepartmentId + ": " + item.Name);
                }
            }
            else if (entity == "Project")
            {
                List<Project> projects = rest.Get<Project>("Project");
                foreach (var item in projects)
                {
                    Console.WriteLine(item.ProjectId + ": " + item.Title);
                }
            }
            else if (entity == "ProjectAssignment")
            {
                List<ProjectAssignment> projectAssignments = rest.Get<ProjectAssignment>("ProjectAssignment");
                foreach (var item in projectAssignments)
                {
                    Console.WriteLine(item.ProjectAssignmentId + ": " + item.Project);
                }
            }
                Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Employee")
            {
                Console.Write("Enter Employee's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Employee one = rest.Get<Employee>(id, "Employee");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "Employee");
            }
            else if (entity == "Department")
            {
                Console.Write("Enter Department's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Department one = rest.Get<Department>(id, "Department");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "Department");
            }
            else if (entity == "Project")
            {
                Console.Write("Enter Project's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Project one = rest.Get<Project>(id, "Project");
                Console.Write($"New name [old: {one.Title}]: ");
                string name = Console.ReadLine();
                one.Title = name;
                rest.Put(one, "Project");
            }
            else if (entity == "ProjectAssignment")
            {
                Console.Write("Enter ProjectAssignment's id to update: ");
                int id = int.Parse(Console.ReadLine());
                ProjectAssignment one = rest.Get<ProjectAssignment>(id, "ProjectAssignment");
                Console.Write($"New name [old: {one.ProjectAssignmentId}]: ");
                string name = Console.ReadLine();
                one.ProjectAssignmentId = int.Parse(name);
                rest.Put(one, "Project");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Employee")
            {
                Console.Write("Enter Employee's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Employee");
            }
            else if (entity == "Department")
            {
                Console.Write("Enter Department's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Department");
            }
            else if (entity == "Project")
            {
                Console.Write("Enter Project's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Project");
            }
            else if (entity == "ProjectAssignment")
            {
                Console.Write("Enter ProjectAssignment's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "ProjectAssignment");
            }
        }

      static void GetEmployeeCountOnProject()
        {
            var barmi = rest.GetSingle<object>("Stat/GetEmployeeCountOnProject?projectId=2");
            Console.WriteLine(barmi);
            Console.ReadLine();
        }

      static void GetDepartmentsInvolvedInProject()
        {
            var barmi = rest.Get<object>("Stat/GetDepartmentsInvolvedInProject?projectId=2");
            foreach (var item in barmi)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadLine();
        }
      static void GetLongestServingEmployeeDetails()
        {
            var barmi = rest.GetSingle<object>("Stat/GetLongestServingEmployeeDetails");
            Console.WriteLine(barmi);
            Console.ReadLine();
        }

      static void DepartmentWorkHoursStatistics()
        {
            var barmi = rest.Get<object>("Stat/DepartmentWorkHoursStatistics");

            foreach (var item in barmi)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

      static void GetDepartmentOfEmployee()
        {
            var barmi = rest.GetSingle<object>("Stat/GetDepartmentOfEmployee?employeeId=2");
            Console.WriteLine(barmi);
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:39574/", "employee");
            
            var employeeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Employee"))
                .Add("Create", () => Create("Employee"))
                .Add("Delete", () => Delete("Employee"))
                .Add("Update", () => Update("Employee"))
                .Add("Exit", ConsoleMenu.Close);

            var departmentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Department"))
                .Add("Create", () => Create("Department"))
                .Add("Delete", () => Delete("Department"))
                .Add("Update", () => Update("Department"))
                .Add("Exit", ConsoleMenu.Close);

            var projectassignSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("ProjectAssignment"))
                .Add("Create", () => Create("ProjectAssignment"))
                .Add("Delete", () => Delete("ProjectAssignment"))
                .Add("Update", () => Update("ProjectAssignment"))
                .Add("Exit", ConsoleMenu.Close);

            var projectSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Project"))
                .Add("Create", () => Create("Project"))
                .Add("Delete", () => Delete("Project"))
                .Add("Update", () => Update("Project"))
                .Add("Exit", ConsoleMenu.Close);
            var statSubMenu = new ConsoleMenu(args, level: 1)
               .Add("Employee Count on Project", () => GetEmployeeCountOnProject())
               .Add("Departments Involved in Project", () => GetDepartmentsInvolvedInProject())
               .Add("Longest Serving Employee Details", () => GetLongestServingEmployeeDetails())
               .Add("Department Work Hours Statistics", () => DepartmentWorkHoursStatistics())
               .Add("Department of Employee", () => GetDepartmentOfEmployee())
               .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Employee", () => employeeSubMenu.Show())
                .Add("Department", () => departmentSubMenu.Show())
                .Add("ProjectAssignment", () => projectassignSubMenu.Show())
                .Add("Project", () => projectSubMenu.Show())
                .Add("Statistics", () => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
