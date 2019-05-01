using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAppSandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            if (!DataStore.GetAll().Any())
                return new[] { "There are no values." };
            return new ActionResult<IEnumerable<string>>(DataStore.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return DataStore.GetIndex(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            DataStore.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            DataStore.SetIndex(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DataStore.Delete(id);
        }
    }
}
