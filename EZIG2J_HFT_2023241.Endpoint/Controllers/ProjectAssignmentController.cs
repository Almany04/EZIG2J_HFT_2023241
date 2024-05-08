using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EZIG2J_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAssignmentController : ControllerBase
    {
        // GET: api/<ProjectAssignmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProjectAssignmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProjectAssignmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProjectAssignmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjectAssignmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
