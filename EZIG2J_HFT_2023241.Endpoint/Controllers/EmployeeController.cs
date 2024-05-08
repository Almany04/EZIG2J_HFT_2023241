using EZIG2J_HFT_2023241.Logic;
using EZIG2J_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EZIG2J_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        IEmployeeLogic logic;

        public EmployeeController(IEmployeeLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Employee> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Employee Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Employee value)
        {
            this.logic.Create(value);
        }


        [HttpPut]
        public void Update([FromBody] Employee value)
        {
            this.logic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

    }
}
