using EZIG2J_HFT_2023241.Logic.Interfaces;
using EZIG2J_HFT_2023241.Models;
using EZIG2J_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace EZIG2J_HFT_2023241.Logic.Classes
{
    public class EmployeeLogic : IEmployeeLogic
    {
        IRepository<Employee> repo;

        public EmployeeLogic(IRepository<Employee> repo)
        {
            this.repo = repo;
        }

        public void Create(Employee item)
        {
            if (item.Name.Length < 3)
            {
                throw new ArgumentException("The Name is too short..");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Employee Read(int id)
        {
            var employee = repo.Read(id);
            if (employee == null)
            {
                throw new ArgumentException("This employee does not exists");
            }
            return employee;

        }

        public IQueryable<Employee> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Employee item)
        {
            repo.Update(item);
        }

        //Non-CRUD metodusok


        //Dolgozók száma egy adott Projecten
        public int GetEmployeeCountOnProject(int projectId)
        {
            return repo.ReadAll()
                       .SelectMany(e => e.ProjectAssignments)
                       .Count(pa => pa.ProjectId == projectId);
        }


        //Egy adott projektben részt vevő Department-ek listája
        public List<string> GetDepartmentsInvolvedInProject(int projectId)
        {
            return repo.ReadAll()
                       .Where(e => e.ProjectAssignments.Any(pa => pa.ProjectId == projectId))
                       .Select(e => e.Department.Name)
                       .Distinct()
                       .ToList();
        }


        //A legrégebben dolgozó alkalmazott neve és munkaköre
        public string GetLongestServingEmployeeDetails()
        {
            var longestServingEmployee = repo.ReadAll().OrderBy(e => e.HireDate).FirstOrDefault();
            if (longestServingEmployee != null)
            {
                return $"{longestServingEmployee.Name} - {longestServingEmployee.Department.Name}";
            }
            return "Nincs alkalmazott az adatbázisban.";
        }
        //Dolgozók munkaidőtartamának összesítésére osztályonként
        public IEnumerable<DepartmentWorkHoursInfo> DepartmentWorkHoursStatistics()
        {
            return from e in repo.ReadAll()
                   group e by e.DepartmentId into g
                   select new DepartmentWorkHoursInfo()
                   {
                       DepartmentId = g.Key,
                       TotalWorkHours = g.Sum(e => (DateTime.Now - e.HireDate).TotalHours)
                   };
        }

        public class DepartmentWorkHoursInfo
        {
            public int DepartmentId { get; set; }
            public double TotalWorkHours { get; set; }
        }

        //Az egyes projekteken dolgozók összesített munkaidőtartama
        public Dictionary<string, double> GetTotalWorkHoursPerProject()
        {
            var result = new Dictionary<string, double>();

            var projects = repo.ReadAll().SelectMany(e => e.ProjectAssignments).GroupBy(pa => pa.ProjectId);

            foreach (var project in projects)
            {
                var totalWorkHours = project.Select(pa => (pa.Project.EndDate - pa.Project.StartDate).TotalHours).Sum();
                result.Add(project.First().Project.Title, totalWorkHours);
            }

            return result;
        }

    }
}

