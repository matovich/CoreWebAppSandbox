using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            AddCookieKeyValue("my_data", "85423125", 2000);
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


        /// <summary>
        /// set the cookie
        /// </summary>
        /// <param name="key">key (unique identifier)</param>
        /// <param name="value">value to store in cookie object</param>
        /// <param name="expireInMinutes">expiration time</param>
        public void AddCookieKeyValue(string key, string value, int? expireInMinutes)
        {
            // https://www.c-sharpcorner.com/article/asp-net-core-working-with-cookie/
            CookieOptions option = new CookieOptions();

            if (expireInMinutes.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireInMinutes.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }

        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
