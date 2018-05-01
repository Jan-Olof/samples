using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Samples.WebApi.Controllers
{
    /// <summary>
    /// Values controller
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// DELETE api/values/5
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        /// <summary>
        /// GET api/values
        /// </summary>
        [HttpGet]
        public IEnumerable<string> Get()
            => new[] { "value1", "value2" };

        /// <summary>
        /// GET api/values/5
        /// </summary>
        [HttpGet("{id}")]
        public string Get(int id)
            => "value";

        /// <summary>
        /// GET error message.
        /// </summary>
        [HttpGet("error")]
        public IEnumerable<string> GetError()
            => throw new NotImplementedException();

        /// <summary>
        /// POST api/values
        /// </summary>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// PUT api/values/5
        /// </summary>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}