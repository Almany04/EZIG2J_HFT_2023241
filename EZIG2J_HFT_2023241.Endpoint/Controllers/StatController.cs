using EZIG2J_HFT_2023241.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static EZIG2J_HFT_2023241.Logic.EmployeeLogic;



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
