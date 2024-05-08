
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
        }
        static void Delete(string entity)
        {
            if (entity == "Employee")
            {
                Console.Write("Enter Employee's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Employee");
            }
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
