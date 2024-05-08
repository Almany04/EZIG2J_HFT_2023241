using EZIG2J_HFT_2023241.Logic;
using EZIG2J_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace EZIG2J_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectAssignmentController : ControllerBase
    {

        IProjectAssignmentLogic logic;

        public ProjectAssignmentController(IProjectAssignmentLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<ProjectAssignment> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public ProjectAssignment Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] ProjectAssignment value)
        {
            this.logic.Create(value);
        }


        [HttpPut]
        public void Update([FromBody] ProjectAssignment value)
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
