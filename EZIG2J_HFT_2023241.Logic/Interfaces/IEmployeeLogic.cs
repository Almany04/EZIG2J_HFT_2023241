using EZIG2J_HFT_2023241.Logic;
using EZIG2J_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace EZIG2J_HFT_2023241.Logic
{
    public interface IEmployeeLogic
    {
        void Create(Employee item);
        void Delete(int id);
        IEnumerable<EmployeeLogic.DepartmentWorkHoursInfo> DepartmentWorkHoursStatistics();
        List<string> GetDepartmentsInvolvedInProject(int projectId);
        int GetEmployeeCountOnProject(int projectId);
        string GetLongestServingEmployeeDetails();
        string GetDepartmentOfEmployee(int employeeId);
        Employee Read(int id);
        IQueryable<Employee> ReadAll();
        void Update(Employee item);
    }
}