using EZIG2J_HFT_2023241.Endpoint.Services;
using EZIG2J_HFT_2023241.Logic;
using EZIG2J_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace EZIG2J_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        IProjectLogic logic;
        IHubContext<SignalRHub> hub;

        public ProjectController(IProjectLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<Project> ReadAll()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Project Read(int id)
        {
            return this.logic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Project value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ProjectCreated", value);
        }


        [HttpPut]
        public void Update([FromBody] Project value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ProjectUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var projectToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ProjectDeleted", projectToDelete);
        }
    }
}
