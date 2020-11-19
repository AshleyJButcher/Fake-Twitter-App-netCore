using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwitterCloneAPI.DataSource;
using TwitterCloneAPI.Interfaces;
using TwitterCloneAPI.Models;

namespace TwitterCloneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TweetsController : ControllerBase
    {


        // GET api/values/5
        [HttpGet("{id}")]
        public List<clientTweet> Get(int id)
        {
            return Startup.thesource.GetTweets(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]clientNewTweet value)
        {
            Startup.thesource.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clientTweet value)
        {
            Startup.thesource.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Startup.thesource.Delete(id);
        }
    }
}
