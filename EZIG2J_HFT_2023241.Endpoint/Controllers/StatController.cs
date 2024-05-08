using EZIG2J_HFT_2023241.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static EZIG2J_HFT_2023241.Logic.EmployeeLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZIG2J_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IEmployeeLogic logic;

        public StatController(IEmployeeLogic logic)
        {
            this.logic = logic;
        }

       
        [HttpGet]
        public int GetEmployeeCountOnProject(int projectId)
        {
            return this.logic.GetEmployeeCountOnProject(projectId);
        }
        /*  public string GetLongestServingEmployeeDetails()
        {
            var longestServingEmployee = repo.ReadAll().OrderBy(e => e.HireDate).FirstOrDefault();
            if (longestServingEmployee != null)
            {
                return $"{longestServingEmployee.Name} - {longestServingEmployee.Department.Name}";
            }
            throw new Exception("Nincs alkalmazott az adatbázisban.");
        }
         */
        [HttpGet]
        public List<string> GetDepartmentsInvolvedInProject(int projectId)
        {
            return this.logic.GetDepartmentsInvolvedInProject(projectId);
        }
        [HttpGet]
        public string GetLongestServingEmployeeDetails()
        {
            return this.logic.GetLongestServingEmployeeDetails();
        }
        [HttpGet]
        public IEnumerable<DepartmentWorkHoursInfo> DepartmentWorkHoursStatistics()
        {
            return this.logic.DepartmentWorkHoursStatistics();
        }
        [HttpGet]
        public string GetDepartmentOfEmployee(int employeeId)
        {
            return this.logic.GetDepartmentOfEmployee(employeeId);
        }
    }

}
